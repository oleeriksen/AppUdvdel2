using Core.Model;

namespace ServerAPI.Repositories;

public class ToDoRepositoryInMemory
{

    private List<TodoItem> mTodo = 
    [ 
        new TodoItem {Id=1, IsDone = false, Title="lektier"}, 
        new TodoItem{Id=2, IsDone=false, Title = "flere lektier"}
    ];

        
    public void Add(TodoItem item)
    {
        // item must have a unique id...
        // solution 1: compute the maximal id, and 1 one to that
        if (mTodo.Count == 0)
            item.Id = 1;
        else
            item.Id = mTodo.Select(b => b.Id).Max() + 1;
        // solution 2: pick a random number...
        mTodo.Add(item);  
    }

    public void DeleteById(int id)
    {
        mTodo.RemoveAll((b) => b.Id == id);
    }

    public List<TodoItem> GetAll()
    {
        return mTodo;
    }

    public void Toogle(int id)
    {
        foreach (TodoItem item in mTodo)
        {
            if (item.Id == id)
            {
                item.IsDone = !item.IsDone;
                break;
            }
        }
    }
}