using HTW.Todo.Data.TodoItemData;
using Microsoft.Extensions.DependencyInjection;

namespace HTW.Todo.Data
{
    public static class ServiceCollectionExtension
    {
        public static void AddDataLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddEntityFrameworkSqlite().AddDbContext<DataContext>();
            serviceCollection.AddScoped<ITodoItemData, TodoItemData.TodoItemData>();
        }
    }
}