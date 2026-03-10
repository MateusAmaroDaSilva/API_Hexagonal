using ApiHexagonal.Domain.Entities;

namespace ApiHexagonal.Domain.Interfaces
{
    public interface ITurmaRepository
    {
        public Turma GetById(int Id);
        public List<Turma> Get();
        public Task Save(Turma Turma);
    }
}
