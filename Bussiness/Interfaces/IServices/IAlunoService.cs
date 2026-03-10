using ApiHexagonal.Bussiness.DTOs;
using ApiHexagonal.Bussiness.Entities;

namespace ApiHexagonal.Bussiness.Interfaces.IServices
{
    public interface IAlunoService
    {
        public List<Aluno> ListStudents();
        public Aluno GetStudent(int Id);
        public Aluno GetStudentRA(int ra);
        public Task Matricular(AlunoDTO AlunoDTO);
    }
}
