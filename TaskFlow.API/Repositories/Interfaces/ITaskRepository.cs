using TaskFlow.API.Common;
using TaskFlow.API.Domain.Entities;

namespace TaskFlow.API.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(int id);
        Task AddAsync(TaskItem task);
        Task UpdateAsync(TaskItem task);
        Task DeleteAsync(int id);
        Task<PagedResult<TaskItem>> GetAllAsync(int pageNumber, int pageSize);
    }
}
