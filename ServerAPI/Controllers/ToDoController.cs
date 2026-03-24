using Core.Model;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;
using WebApp.Model;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/todo")]
public class ToDoController : ControllerBase
{
    private static readonly ToDoRepositoryInMemory todoRepo = new();

    [HttpGet]
    public List<TodoItem> Get()
    {
        return new();
    }

    [HttpPost]
    public void Add(TodoItem item)
    {
        
    }

    [HttpDelete]
    [Route("delete/{id:int}")]
    public void Delete(int id)
    {
        
    }

    [HttpDelete]
    [Route("delete")]
    public void DeleteByQuery([FromQuery] int id)
    {
        
    }
}