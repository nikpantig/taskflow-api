namespace TaskFlow.API.DTOs
{
    public class CreateTaskItemDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
