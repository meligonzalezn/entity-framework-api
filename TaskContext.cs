using Microsoft.EntityFrameworkCore;
using minimal_api_ef.Models;
using Task = minimal_api_ef.Models.Task;

namespace minimal_api_ef;

public class TaskContext: DbContext
{
    public DbSet<Category> Categories { get; set;  }
    public DbSet<Task> Tasks { get; set; }
    public TaskContext(DbContextOptions<TaskContext> options) : base(options) {}
    // This is to override the method to create database with ET
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // to build restrictions for category model
        modelBuilder.Entity<Category>(category =>
        {
            // tables should be singular (normalization rule)
            category.ToTable("Category");
            // to define primary key
            category.HasKey(p=> p.CategoryId);
            category.Property(p => p.Name).IsRequired().HasMaxLength(150);
            category.Property(p => p.Description);
        });

        modelBuilder.Entity<Task>(task =>
        {
            task.ToTable("Task");
            task.HasKey(p => p.TaskId);
            // Foreign key
            task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);
            task.Property(p => p.Title).IsRequired().HasMaxLength(200);
            task.Property(p => p.Description);
            task.Property(p => p.TaskPriority);
            task.Property(p => p.CreationDate);
        });
    }
}