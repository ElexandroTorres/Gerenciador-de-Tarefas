using GerenciadorDeTarefas.Models;

namespace GerenciadorDeTarefas.Repository
{
    public interface ITodoRepository
    {
        Todo AddTodo(Todo todo);
        Todo EditTodo(Todo todo);
        bool DeleteTodo(Todo todo);
        Todo FindTodoById(int id);
        List<Todo> FindAll();
    }
}
