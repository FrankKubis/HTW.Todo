using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HTW.Todo.Domain;
using Microsoft.EntityFrameworkCore;

namespace HTW.Todo.Data.TodoItemData
{
    public class TodoItemData : ITodoItemData
    {
        private readonly DataContext _dataContext;

        public TodoItemData(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<TodoItem>> Get()
            => (await _dataContext.TodoItems.ToListAsync()).Select(x => CreateDomainModel(x));

        public async Task<TodoItem> Get(int id)
            => CreateDomainModel(await _dataContext.TodoItems.FirstOrDefaultAsync(x => x.Id == id));

        public async Task<TodoItem> Add(TodoItem todoItem)
        {
            var item = new Data.Model.TodoItem
            {
                Description = todoItem.Description,
                Title = todoItem.Title,
                IsDone = todoItem.IsDone
            };
            await _dataContext.TodoItems.AddAsync(item);
            await _dataContext.SaveChangesAsync();

            return CreateDomainModel(item);
        }

        public async Task Update(TodoItem todoItem)
        {
            var item = await _dataContext.TodoItems.FirstOrDefaultAsync(x => x.Id == todoItem.Id);
            item.Description = todoItem.Description;
            item.Title = todoItem.Title;
            item.IsDone = todoItem.IsDone;
            _dataContext.TodoItems.Update(item);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await _dataContext.TodoItems.FirstOrDefaultAsync(x => x.Id == id);
            _dataContext.Remove(item);
            await _dataContext.SaveChangesAsync();
        }

        private static TodoItem CreateDomainModel(Model.TodoItem x)
        {
            if (x == null)
            {
                return null;
            }
            
            return new TodoItem
            {
                Id = x.Id,
                Description = x.Description,
                Title = x.Title,
                IsDone = x.IsDone
            };
        }
    }
}