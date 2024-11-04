using Microsoft.AspNetCore.Mvc;
using Core;
using ServerAPI.Repositories;
using WebApp1.Model;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/todo")]
public class ToDoController : ControllerBase
{
    private IToDoRepository mRepo;

    public ToDoController(IToDoRepository repo){
        mRepo = repo;
    }

    [HttpGet]
    [Route("getall")]
    public List<ToDoItem> GetAll(){
        return mRepo.GetAll();
    }

    [HttpPost]
    [Route("add")]
    public void AddItem(ToDoItem item){
        mRepo.Add(item);  
    }

    [HttpDelete]
    [Route("delete/{id:int}")]
    public void DeleteItem(int id) {
        mRepo.Delete( new ToDoItem {Id = id});
    }

    [HttpPut]
    [Route("update")]
    public void UpdateItem(ToDoItem item){
        mRepo.Update(item);
    }


}