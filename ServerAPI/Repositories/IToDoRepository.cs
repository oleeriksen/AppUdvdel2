using WebApp1.Model;

namespace ServerAPI.Repositories;

public interface IToDoRepository
{
    List<ToDoItem> GetAll();
    void Add(ToDoItem item);
    void Delete(ToDoItem item);
    void Update(ToDoItem item);

}