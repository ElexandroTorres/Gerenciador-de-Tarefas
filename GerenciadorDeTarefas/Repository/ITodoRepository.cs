using GerenciadorDeTarefas.Models;

namespace GerenciadorDeTarefas.Repository
{
    public interface ITodoRepository
    {
        Todo AddTodo(Todo todo);
        Todo EditTodo(Todo todo);
        bool DeleteTodo(int id);
        Todo FindTodoById(int id);
        List<Todo> FindAll();
    }
}
