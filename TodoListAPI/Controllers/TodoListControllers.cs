using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using TodoListAPI.Models;
using TodoListAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace TodoListAPI.Controllers;

[ApiController]
[Route("{controller}/{action}")]
public class TodoListController : ControllerBase
{
    private readonly TodoListContext db;

    public TodoListController(TodoListContext context)
    {
        db = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
    {
        List<TodoItem> todos = await db.TodoItems.ToListAsync();
        return todos;
    }
    [HttpGet]
    public async Task<ActionResult<TodoItem>> GetById(Guid id)
    {
        var todo = await db.TodoItems.FindAsync(id);
        if (todo == null)
        {
            return NotFound();
        };
        return todo;
    }
    [HttpPost]
    public async Task<ActionResult<TodoItem>> CreateTodoItem(TodoItem todoItem)
    {
        if (todoItem == null)
        {
            return BadRequest();
        }

        db.TodoItems.Add(todoItem);
        await db.SaveChangesAsync();

        // Return a 201 Created response with the created entity and location header
        return CreatedAtAction(nameof(GetById), new { id = todoItem.Id }, todoItem);
    }
    [HttpPost]
    public async Task<ActionResult<TodoItem>> CompleteTodoItem(Guid id)
    {
        var todoItem = await db.TodoItems.FindAsync(id);
        if (todoItem == null)
        {
            return NotFound();
        }

        todoItem.CompletedDate = DateTime.Now; // Set the current date and time as CompletedDate
        await db.SaveChangesAsync(); // Save changes to the database

        return todoItem; // Return a success status code
    }


}