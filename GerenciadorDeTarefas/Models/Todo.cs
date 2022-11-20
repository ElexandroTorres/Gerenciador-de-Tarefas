using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeTarefas.Models
{
    public class Todo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "É necessario informar o titulo da tarefa.")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "É necessario informar a data de conclusão da tarefa.")]
        public DateTime DateOfConclusion { get; set; } = DateTime.Now;

    }
}
