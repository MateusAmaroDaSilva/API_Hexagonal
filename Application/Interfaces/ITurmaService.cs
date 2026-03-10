using ApiHexagonal.Application.DTOs;
using ApiHexagonal.Domain.Entities;

namespace ApiHexagonal.Application.Interfaces
{
    public interface ITurmaService
    {
        public List<Turma> ListClassroom();
        public Turma GetClassroom(int Id);
        public Task Registrar(TurmaDTO TurmaDTO);
    }
}
