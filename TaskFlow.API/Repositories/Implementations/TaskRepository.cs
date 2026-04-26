using Microsoft.EntityFrameworkCore;
using TaskFlow.API.Common;
using TaskFlow.API.Data;
using TaskFlow.API.Domain.Entities;
using TaskFlow.API.Repositories.Interfaces;


namespace TaskFlow.API.Repositories.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await _context.TaskItems
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _context.TaskItems
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(TaskItem task)
        {
            await _context.TaskItems.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaskItem task)
        {
            _context.TaskItems.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var task = await _context.TaskItems.FindAsync(id);

            if (task == null)
                return;

            _context.TaskItems.Remove(task);
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<TaskItem>> GetAllAsync(int pageNumber, int pageSize)
        {
            var query = _context.TaskItems.AsNoTracking();

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(t => t.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<TaskItem>
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }
    }
}
