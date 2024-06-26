using System.ComponentModel.DataAnnotations;

namespace minimal_api_ef.Models;

public class Category
{
    //[Key] -- we don't need it anymore due to fluent API
    public Guid CategoryId { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    public int Point { get; set; } 
    public virtual ICollection<Task> Tasks { get; set; }
}