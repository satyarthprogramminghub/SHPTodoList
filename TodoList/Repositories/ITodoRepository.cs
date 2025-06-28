using TodoList.Models;

namespace TodoList.Repositories
{
    public interface ITodoRepository
    {
        // Retrieves all Todo items
        List<TodoItem> GetAll();
        // Retrieves a Todo item by ID
        TodoItem? GetById(int id);
        // Adds a new Todo item
        void Add(TodoItem item);

        // Updates an existing Todo item
        void Update(TodoItem item);

        // Deletes a Todo item by ID
        void Delete(int id);
    }
}
