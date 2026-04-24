using Microsoft.EntityFrameworkCore;
using TaskFlow.API.Common;
using TaskFlow.API.Data;
using TaskFlow.API.Domain.Entities;
using TaskFlow.API.Repositories.Interfaces;


namespace TaskFlow.API.Repositories.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private static readonly List<TaskItem> _tasks = new();
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return Task.FromResult(_tasks.AsEnumerable());
        }

        public Task<TaskItem?> GetByIdAsync(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            return Task.FromResult(task);
        }

        public Task AddAsync(TaskItem task)
        {
            task.Id = _tasks.Count + 1;
            _tasks.Add(task);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(TaskItem task)
        {
            var existing = _tasks.FirstOrDefault(t => t.Id == task.Id);
            if (existing != null)
            {
                existing.Title = task.Title;
                existing.Description = task.Description;
                existing.IsComplete = task.IsComplete;
                existing.UpdatedAt = DateTime.UtcNow;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
            }

            return Task.CompletedTask;
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
