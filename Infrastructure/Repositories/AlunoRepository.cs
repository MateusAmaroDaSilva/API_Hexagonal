using ApiHexagonal.Domain.Entities;
using ApiHexagonal.Domain.Interfaces;
using ApiHexagonal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiHexagonal.Infrastructure.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        public readonly Context _database;

        public AlunoRepository(Context database)
        {
            _database = database;
        }

        public Aluno GetById(int Id)
        {
            Aluno Aluno = _database.Aluno
                    .Select(std => std)
                    .Where(std => std.Id == Id)
                    .Include(std => std.Turma)
                    .FirstOrDefault();
            return Aluno;
        }

        public Aluno GetByEmail(string email)
        {
            Aluno Aluno = _database.Aluno
                    .Select(std => std)
                    .Where(std => std.Email == email)
                    .FirstOrDefault();
            return Aluno;
        }

        public Aluno GetByRA(int ra)
        {
            Aluno Aluno = _database.Aluno
                    .Select(std => std)
                    .Where(std => std.RA == ra)
                    .Include(std => std.Turma)
                    .FirstOrDefault();
            return Aluno;
        }
        public List<Aluno> Get()
        {
            List<Aluno> alunos = _database.Aluno
                .Select(std => std)
                .ToList();
            return alunos;
        }
        public async Task Save(Aluno Aluno)
        {
            _database.Add(Aluno);
            await _database.SaveChangesAsync();
        }


    }
}
