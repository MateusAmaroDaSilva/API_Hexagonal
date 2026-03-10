using ApiHexagonal.Bussiness.Entities;

namespace ApiHexagonal.Bussiness.Interfaces.IRepositories
{
    public interface ITurmaRepository
    {
        public Turma GetById(int Id);
        public List<Turma> Get();
        public Task Save(Turma Turma);
    }
}
