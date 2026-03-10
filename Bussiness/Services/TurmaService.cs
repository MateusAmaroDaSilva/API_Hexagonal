using ApiHexagonal.Bussiness.DTOs;
using ApiHexagonal.Bussiness.Entities;
using ApiHexagonal.Bussiness.Interfaces.IRepositories;
using ApiHexagonal.Bussiness.Interfaces.IServices;

namespace ApiHexagonal.Bussiness.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _repository;
        public TurmaService(ITurmaRepository repository)
        {
            _repository = repository;
        }

        public List<Turma> ListClassroom()
        {
            try
            {
                List<Turma> Turma = _repository.Get();
                return Turma;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public Turma GetClassroom(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    throw new Exception("Id de Aluno Invalido");
                }

                Turma Turma = _repository.GetById(Id);

                if(Turma == null)
                {
                    return null;
                }

                return Turma;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task Registrar(TurmaDTO TurmaDTO)
        {
            try
            {
                if (TurmaDTO == null)
                {
                    throw new Exception("Classe Cadastrada Invalida");
                }


                Turma newClassroom = new Turma();
                newClassroom.Name = TurmaDTO.Name;
                newClassroom.Course = TurmaDTO.Course;

                if (newClassroom == null)
                {
                    throw new Exception("Classe Cadastrada Invalida");
                }

                await _repository.Save(newClassroom);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
