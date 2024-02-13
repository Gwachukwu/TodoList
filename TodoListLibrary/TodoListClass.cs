using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TodoListAPI.Models;

public class TodoItem
{
    [Key]
    public Guid Id { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public string Description { get; set; }
};