using Microsoft.EntityFrameworkCore;
using TaskFlow.API.Domain.Entities;

namespace TaskFlow.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        public DbSet<TaskItem> TaskItems => Set<TaskItem>();
    }
}
