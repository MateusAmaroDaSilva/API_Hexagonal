using ApiHexagonal.Bussiness.DTOs;
using ApiHexagonal.Bussiness.Entities;

namespace ApiHexagonal.Bussiness.Interfaces.IServices
{
    public interface ITurmaService
    {
        public List<Turma> ListClassroom();
        public Turma GetClassroom(int Id);
        public Task Registrar(TurmaDTO TurmaDTO);
    }
}
