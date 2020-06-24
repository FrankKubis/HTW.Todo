using System.Collections.Generic;
using System.Threading.Tasks;
using HTW.Todo.Domain;

namespace HTW.Todo.Data.TodoItemData
{
    public interface ITodoItemData
    {
        Task<IEnumerable<TodoItem>> Get();
        
        Task<TodoItem> Get(int id);
        
        Task<TodoItem> Add(TodoItem todoItem);
        
        Task Delete(int id);
        
        Task Update(TodoItem todoItem);
    }
}