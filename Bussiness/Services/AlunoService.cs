using ApiHexagonal.Bussiness.DTOs;
using ApiHexagonal.Bussiness.Entities;
using ApiHexagonal.Bussiness.Interfaces.IRepositories;
using ApiHexagonal.Bussiness.Interfaces.IServices;

namespace ApiHexagonal.Bussiness.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _studentRepository;
        private readonly ITurmaRepository _classroomRepository;
        public AlunoService(IAlunoRepository AlunoRepository, ITurmaRepository TurmaRepository)
        {
            _studentRepository = AlunoRepository;
            _classroomRepository = TurmaRepository;
        }

        public List<Aluno> ListStudents()
        {
            try
            {
                List<Aluno> alunos = _studentRepository.Get();
                return alunos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Aluno GetStudent(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    throw new Exception("Id de Aluno Invalido");
                }

                Aluno Aluno = _studentRepository.GetById(Id);

                if(Aluno == null)
                {
                    return null;
                }

                return Aluno;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Aluno GetStudentRA(int ra)
        {
            try
            {
                if (ra == null)
                {
                    throw new Exception("RA do Aluno Invalido");
                }

                Aluno Aluno = _studentRepository.GetByRA(ra);

                if (Aluno == null)
                {
                    return null;
                }

                return Aluno;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task Matricular(AlunoDTO AlunoDTO)
        {
            try
            {
                if (AlunoDTO == null)
                {
                    throw new Exception("Matricula Invalida!");
                }


                if (AlunoDTO.FirstName == null || AlunoDTO.FirstName == "")
                {
                    throw new Exception("O Aluno Precisa ter o Primeiro Nome!");
                }
                else if (AlunoDTO.FirstName.Length > 50)
                {
                    throw new Exception("O Primeiro Nome do Aluno deve ter no Máximo 50 caracteres");
                }


                var AlunoEmail = _studentRepository.GetByEmail(AlunoDTO.Email);
                if (!AlunoDTO.Email.EndsWith("@faculdade.edu"))
                {
                    throw new Exception("O Email deve terminar obrigatoriamente com '@faculdade.edu'");
                }
                else if(AlunoEmail != null)
                {
                    throw new Exception("Este Email já pertence a um Aluno!");
                }


                var AlunoRA = _studentRepository.GetByRA(AlunoDTO.RA);
                if (AlunoDTO.RA <= 0)
                {
                    throw new Exception("Este RA é Invalido!");
                } 
                else if (AlunoRA != null)
                {
                    throw new Exception("Este RA já pertence a um Aluno!");
                }

                var savedTurma = _classroomRepository.GetById(AlunoDTO.TurmaId);
                if (savedTurma == null)
                {
                    throw new Exception("Turma não existente");
                }

                Aluno newAluno = new Aluno();
                newAluno.FirstName = AlunoDTO.FirstName;
                newAluno.LastName = AlunoDTO.LastName;
                newAluno.Email = AlunoDTO.Email;
                newAluno.RA = AlunoDTO.RA;
                newAluno.TurmaId = AlunoDTO.TurmaId;
                newAluno.RegisterDate = DateTime.Now;

                await _studentRepository.Save(newAluno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }
    }
}
