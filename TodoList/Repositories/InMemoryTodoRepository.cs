using TodoList.Models;

namespace TodoList.Repositories
{
    public class InMemoryTodoRepository : ITodoRepository
    {
        // In-memory list to store Todo items
        private readonly List<TodoItem> _todos = new List<TodoItem>();

        // Tracks the next available ID for new Todo items
        private int _nextId = 1;

        // Retrieves all Todo items
        public List<TodoItem> GetAll()
        {
            return _todos;
        }

        // Retrieves a Todo item by its ID
        public TodoItem? GetById(int id)
        {
            return _todos.FirstOrDefault(todo => todo.Id == id);
        }

        // Adds a new Todo item to the repository
        public void Add(TodoItem item)
        {
            item.Id = _nextId++;
            _todos.Add(item);
        }
        
        // Updates an existing Todo item
        public void Update(TodoItem item)
        {
            var existing = GetById(item.Id);

            if (existing != null)
            {
                existing.Title = item.Title;
                existing.Description = item.Description; // Ensures Description is updated
                existing.IsCompleted = item.IsCompleted;
            }
        }
        
        // Deletes a Todo item by its ID
        public void Delete(int id)
        {
            var item = GetById(id);

            if (item != null)
            {
                _todos.Remove(item);
            }
        }

    }
}
