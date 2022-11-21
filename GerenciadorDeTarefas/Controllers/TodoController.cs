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
            if (ModelState.IsValid)
            {
                _todoRepository.AddTodo(todo);
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        public IActionResult Edit(int id)
        {
            Todo todo = _todoRepository.FindTodoById(id);
            return View(todo);
            
        }

        [HttpPost]
        public IActionResult Edit(Todo todo)
        {
            if(ModelState.IsValid)
            {
                _todoRepository.EditTodo(todo);
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        public IActionResult Delete(int id)
        {
            Todo todo = _todoRepository.FindTodoById(id);
            return View(todo);
        }

        public IActionResult DeleteTodo(int id)
        {
            _todoRepository.DeleteTodo(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
