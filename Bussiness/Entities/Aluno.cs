using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiHexagonal.Bussiness.Entities
{
    public class Aluno
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RA { get; set; }
        public string Email { get; set; }
        public int TurmaId { get; set; }
        public Turma Turma { get; set; }
        public DateTime RegisterDate { get; set; }

        public Aluno()
        {

            RegisterDate = DateTime.Now;
        }
    }
}
