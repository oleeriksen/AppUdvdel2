using Core.Model;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;


namespace ServerAPI.Controllers;

[ApiController]
[Route("api/todo")]
public class ToDoController : ControllerBase
{
    private static readonly ToDoRepositoryInMemory todoRepo = new();

    [HttpGet]
    public List<TodoItem> Get()
    {
        return todoRepo.GetAll();
    }

    [HttpPost]
    public void Add(TodoItem item)
    {
        todoRepo.Add(item);
    }

    [HttpDelete]
    [Route("delete/{id:int}")]
    public void Delete(int id)
    {
        todoRepo.DeleteById(id);
    }

    [HttpDelete]
    [Route("delete")]
    public void DeleteByQuery([FromQuery] int id)
    {
        todoRepo.DeleteById(id);
    }

    [HttpPut]
    [Route("toogle/{id:int}")]
    public void ToggleItem(int id)
    {
        todoRepo.Toogle(id);
    }
}