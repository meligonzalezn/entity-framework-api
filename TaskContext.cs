using Microsoft.EntityFrameworkCore;
using minimal_api_ef.Models;
using Task = minimal_api_ef.Models.Task;

namespace minimal_api_ef;

public class TaskContext: DbContext
{
    public DbSet<Category> Categories { get; set;  }
    public DbSet<Task> Tasks { get; set; }
    public TaskContext(DbContextOptions<TaskContext> options) : base(options) {}
}