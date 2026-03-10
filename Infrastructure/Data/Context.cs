using ApiHexagonal.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiHexagonal.Infrastructure.Data
{
    public class Context : DbContext
    {
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>()
                .ToTable("Aluno")
                .HasKey(std => std.Id);

            modelBuilder.Entity<Turma>()
                .ToTable("Turma")
                .HasKey(clr => clr.Id);

            modelBuilder.Entity<Aluno>()
                .HasOne(std => std.Turma)
                .WithMany(clr => clr.alunos)
                .HasForeignKey(clr => clr.TurmaId);

            base.OnModelCreating(modelBuilder);
        }
    }

}
