using ApiHexagonal.Domain.Entities;

namespace ApiHexagonal.Domain.Interfaces
{
    public interface IAlunoRepository
    {
        public Aluno GetById(int Id);
        public Aluno GetByRA(int ra);
        public List<Aluno> Get();
        public Task Save(Aluno Aluno);
        public Aluno GetByEmail(string email);
    }
}
