using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Repositories;

namespace TodoList.Controllers
{
    public class TodoController : Controller
    {
        // Repository interface injected via Dependency Injection
        private readonly ITodoRepository _repository;

        // Constructor injection of the repository
        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        // GET: /Todo/ - Displays the list of Todo items
        public IActionResult Index()
        {
            var todos = _repository.GetAll();
            return View(todos);
        }

        // GET: /Todo/Create - Shows the form to create a new Todo item
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Todo/Create - Handles form submission to create a Todo item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TodoItem todo) 
        {

            // Validate that Title is not empty
            if (string.IsNullOrWhiteSpace(todo.Title))
            {
                ModelState.AddModelError("Title", "Title is required.");
            }

            if (ModelState.IsValid)
            {
                _repository.Add(todo);
                TempData["SuccessMessage"] = "Todo item created successfully!";
                return RedirectToAction(nameof(Index));
            }

            return View(todo);
        }

        // GET: /Todo/Edit/5 - Shows the form to edit a Todo item
        public IActionResult Edit(int id)
        {
            var todo = _repository.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        // POST: /Todo/Edit/5 - Handles form submission to update a Todo item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TodoItem todo) 
        {
            // Validate that Title is not empty
            if (string.IsNullOrWhiteSpace(todo.Title))
            {
                ModelState.AddModelError("Title", "Title is required.");
            }

            if (ModelState.IsValid)
            {
                _repository.Update(todo);
                TempData["SuccessMessage"] = "Todo item updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            return View(todo);
        }

        // GET: /Todo/Delete/5 - Shows the confirmation page for deleting a Todo item
        public IActionResult Delete(int id)
        {
            var todo = _repository.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        // POST: /Todo/DeleteConfirmed/5 - Handles deletion of a Todo item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var todo = _repository.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }
            _repository.Delete(id);
            TempData["SuccessMessage"] = "Todo item deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
