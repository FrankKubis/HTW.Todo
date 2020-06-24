using System.Collections.Generic;
using System.Threading.Tasks;
using HTW.Todo.Domain;

namespace HTW.Todo.Business
{
    public interface ITodoItemLogic
    {
        Task<IEnumerable<TodoItem>> Get();
        
        Task<TodoItem> Get(int id);

        Task<TodoItem> Create(TodoItem todoItem);
        
        Task Update(TodoItem todoItem);
        
        Task Delete(int id);
    }
}