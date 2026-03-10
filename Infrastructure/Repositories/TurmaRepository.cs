using ApiHexagonal.Domain.Entities;
using ApiHexagonal.Domain.Interfaces;
using ApiHexagonal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace ApiHexagonal.Infrastructure.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        public readonly Context _database;
        public TurmaRepository(Context database)
        {
            _database = database;
        }
        public Turma GetById(int Id)
        {
            Turma Turma = _database.Turma
                    .Select(clr => clr)
                    .Where(clr => clr.Id == Id)
                    .Include(clr => clr.alunos)
                    .FirstOrDefault();
            return Turma;
        }
        public List<Turma> Get()
        {
            List<Turma> Turma = _database.Turma
                .Select(clr => clr)
                .ToList();
            return Turma;
        }
        public async Task Save(Turma Turma)
        {
            _database.Turma.Add(Turma);
            await _database.SaveChangesAsync();
        }
    }
}
