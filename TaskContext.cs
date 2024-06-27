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
        List<Category> categoriesInit = new List<Category>();
        categoriesInit.Add(new Category()
        {
            CategoryId = Guid.Parse("f8cbb403-432c-4585-a7d1-850685e65aa8"),
            Name = "Pending Activities",
            Point = 20
        });
        categoriesInit.Add(new Category()
        {
            CategoryId = Guid.Parse("f8cbb403-432c-4585-a7d1-850685e65ab6"),
            Name = "Personal Activities",
            Point = 50
        });
        
        // to build restrictions for category model
        modelBuilder.Entity<Category>(category =>
        {
            // tables should be singular (normalization rule)
            category.ToTable("Category");
            // to define primary key
            category.HasKey(p=> p.CategoryId);
            category.Property(p => p.Name).IsRequired().HasMaxLength(150);
            category.Property(p => p.Description).IsRequired(false);
            category.Property(p => p.Point);
            // To seed the database with initial data
            category.HasData(categoriesInit);
        });

        List<Task> tasksInit = new List<Task>();
        tasksInit.Add(new Task()
        {
            TaskId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb410"), 
            CategoryId = Guid.Parse("f8cbb403-432c-4585-a7d1-850685e65aa8"), 
            TaskPriority = Priority.Medium,
            TaskStatus = Status.ToDo,
            Title = "Taxes payment", 
        });
        tasksInit.Add(new Task()
        {
            TaskId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb411"), 
            CategoryId = Guid.Parse("f8cbb403-432c-4585-a7d1-850685e65ab6"), 
            TaskPriority = Priority.Low,
            TaskStatus = Status.Doing,
            Title = "Netflix Payment",
        });
        
        modelBuilder.Entity<Task>(task =>
        {
            task.ToTable("Task");
            task.HasKey(p => p.TaskId);
            // Foreign key
            task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);
            task.Property(p => p.Title).IsRequired().HasMaxLength(200);
            task.Property(p => p.Description).IsRequired(false);
            task.Property(p => p.TaskStatus);
            task.Property(p => p.TaskPriority);
            task.Ignore(p => p.Summary);
            // To seed the database with initial data
            task.HasData(tasksInit);
        });
    }
}