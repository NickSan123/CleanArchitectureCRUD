using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Completed { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public void MarkAsCompleted()
        {
            Completed = true;
            EndDate = DateTime.Now;  // Definindo a data de conclusão
        }
    }
}
