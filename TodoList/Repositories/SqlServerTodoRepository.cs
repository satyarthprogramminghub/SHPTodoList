using TodoList.Data;
using TodoList.Models;

namespace TodoList.Repositories
{
    public class SqlServerTodoRepository : ITodoRepository
    {
        // DbContext injected via Dependency Injection
        private readonly TodoDbContext _context;
        public SqlServerTodoRepository(TodoDbContext context)
        {
            _context = context;
        }

        // Retrieves all Todo items from the database
        public List<TodoItem> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        // Retrieves a Todo item by its ID from the database
        public TodoItem? GetById(int id)
        {
            return _context.TodoItems.FirstOrDefault(todo => todo.Id == id);
        }

        // Adds a new Todo item to the database
        public void Add(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();
        }

        // Updates an existing Todo item in the database
        public void Update(TodoItem item)
        {
            var existing = _context.TodoItems.FirstOrDefault(todo => todo.Id == item.Id);

            if (existing != null)
            {
                existing.Title = item.Title;
                existing.Description = item.Description;
                existing.IsCompleted = item.IsCompleted;
                _context.SaveChanges();
            }
        }

        // Deletes a Todo item by its ID from the database
        public void Delete(int id)
        {
            var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);

            if (todo != null)
            {
                _context.TodoItems.Remove(todo);
                _context.SaveChanges();
            }
        }
    }
}
