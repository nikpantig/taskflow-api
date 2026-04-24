using TaskFlow.API.DTOs;

namespace TaskFlow.API.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItemDto>> GetAllAsync();
        Task<TaskItemDto?> GetByIdAsync(int id);
        Task<TaskItemDto> CreateAsync(CreateTaskItemDto dto);
        Task<bool> UpdateAsync(int id, UpdateTaskItemDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
