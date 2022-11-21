using GerenciadorDeTarefas.Data;
using GerenciadorDeTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext _context;

        public TodoRepository(AppDbContext context)
        {
            _context = context;
        }

        public Todo AddTodo(Todo todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();

            return todo;
        }

        public bool DeleteTodo(int id)
        {
            Todo todoFromDb = FindTodoById(id);

            _context.Todos.Remove(todoFromDb);
            _context.SaveChanges();

            return true;
        }

        public Todo EditTodo(Todo todo)
        {
            Todo todoFromDb = FindTodoById(todo.Id);

            todoFromDb.Title = todo.Title;
            todoFromDb.DateOfConclusion = todo.DateOfConclusion;

            _context.Todos.Update(todoFromDb);
            _context.SaveChanges();

            return todoFromDb;
        }

        public List<Todo> FindAll()
        {
            List<Todo> allTodos = _context.Todos.ToList();
            allTodos.Sort((x, y) => DateTime.Compare(y.DateOfConclusion, x.DateOfConclusion));

            return allTodos;
        }

        public Todo FindTodoById(int id)
        {
            Todo? todoFromDb = _context.Todos.FirstOrDefault(todo => todo.Id == id);

            if(todoFromDb == null)
            {
                throw new Exception("Não foi possivel encontrar a tarefa com o id informado.");
            }

            return todoFromDb;
        }
    }
}