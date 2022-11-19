namespace GerenciadorDeTarefas.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateOfConclusion { get; set; } = DateTime.Now;

    }
}
