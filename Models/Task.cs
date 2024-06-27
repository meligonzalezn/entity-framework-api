using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace minimal_api_ef.Models;

public class Task
{
    public Guid TaskId { get; set; }
    public Guid CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Status TaskStatus { get; set; }
    public Priority TaskPriority { get; set; }
    public virtual Category Category { get; set; }
    [NotMapped]
    public string Summary { get; set; }
}

public enum Priority
{
    Low,
    Medium,
    High
}

public enum Status
{
    ToDo,
    Doing,
    Done
}