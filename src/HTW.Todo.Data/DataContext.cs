using HTW.Todo.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace HTW.Todo.Data
{
    public class DataContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        
        public DataContext()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("DataSource=data.db");
    }
}