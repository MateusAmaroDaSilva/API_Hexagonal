using System.ComponentModel.DataAnnotations;

namespace ApiHexagonal.Application.DTOs
{
    public class AlunoDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RA { get; set; }
        public string Email { get; set; }
        public int TurmaId { get; set; }

    }
}
