using ApiHexagonal.Application.DTOs;
using ApiHexagonal.Domain.Entities;

namespace ApiHexagonal.Application.Interfaces
{
    public interface IAlunoService
    {
        public List<Aluno> ListStudents();
        public Aluno GetStudent(int Id);
        public Aluno GetStudentRA(int ra);
        public Task Matricular(AlunoDTO AlunoDTO);
    }
}
