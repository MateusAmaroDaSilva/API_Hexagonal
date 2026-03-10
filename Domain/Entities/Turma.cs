using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiHexagonal.Domain.Entities
{
    public class Turma
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public virtual List<Aluno> alunos { get; set; }

        public Turma()
        {

        }
    }
}
