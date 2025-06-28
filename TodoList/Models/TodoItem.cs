namespace TodoList.Models
{
    public class TodoItem
    {
        // Unique identifier for the Todo item
        public int Id { get; set; }

        // Title of the Todo item, initialized to avoid null
        public string Title { get; set; } = string.Empty;

        // Description of the Todo item, added for additional details
        public string Description { get; set; } = string.Empty;
        
        // Indicates whether the Todo item is completed
        public bool IsCompleted { get; set; }
    }
}
