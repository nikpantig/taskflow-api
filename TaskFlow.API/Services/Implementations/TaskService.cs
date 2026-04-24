using TaskFlow.API.Domain.Entities;
using TaskFlow.API.DTOs;
using TaskFlow.API.Repositories.Interfaces;
using TaskFlow.API.Services.Interfaces;

namespace TaskFlow.API.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskItemDto>> GetAllAsync()
        { 
            var task = await _repository.GetAllAsync();

            return task.Select(t => new TaskItemDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                IsCompleted = t.IsCompleted,
                CreatedAt = t.CreatedAt,
                UpdatedAt = t.UpdatedAt
            });
        }

        public async Task<TaskItemDto?> GetByIdAsync(int id)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null) return null;
            return new TaskItemDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                CreatedAt = task.CreatedAt,
                UpdatedAt = task.UpdatedAt
            };
        }

        public async Task<TaskItemDto> CreateAsync(CreateTaskItemDto dto)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                IsCompleted = false
            };

            await _repository.AddAsync(task);

            return new TaskItemDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                CreatedAt = task.CreatedAt,
                UpdatedAt = task.UpdatedAt
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateTaskItemDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null) return false;

            existing.Title = dto.Title;
            existing.Description = dto.Description;
            existing.IsCompleted = dto.IsCompleted;
            existing.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(existing);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null) return false;

            await _repository.DeleteAsync(id);

            return true;
        }
    }
}
 