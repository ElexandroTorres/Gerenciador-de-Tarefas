using GerenciadorDeTarefas.Models;
using GerenciadorDeTarefas.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefas.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public IActionResult Index()
        {
            List<Todo> todoList = _todoRepository.FindAll();
            return View(todoList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Todo todo)
        {
            _todoRepository.AddTodo(todo);
            return RedirectToAction(nameof(Index));
        }
    }
}
