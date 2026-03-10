using ApiHexagonal.Bussiness.DTOs;
using ApiHexagonal.Bussiness.Entities;
using ApiHexagonal.Bussiness.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ApiHexagonal.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _service;
        public AlunoController(IAlunoService service)
        {
            _service = service;
        }

        [HttpGet("GetAluno/{Id}")]
        public IActionResult GetStudent(int Id)
        {
            Aluno Aluno = _service.GetStudent(Id);

            if (Aluno == null)
            {
                return NotFound("Aluno não Encontrado");
            }

            return Ok(Aluno);
        }

        [HttpGet("GetAlunoRA/{RA}")]
        public IActionResult GetStudentRA(int RA)
        {
            Aluno Aluno = _service.GetStudentRA(RA);

            if (Aluno == null)
            {
                return NotFound("Aluno não Encontrado");
            }

            return Ok(Aluno);
        }

        [HttpGet("ListAluno")]
        public IActionResult ListStudent()
        {
            List<Aluno> alunos = _service.ListStudents();
            return Ok(alunos);
        }

        [HttpPost("PostAluno")]
        public async Task<IActionResult> PostStudent(AlunoDTO AlunoDTO)
        {
            try
            {
                await _service.Matricular(AlunoDTO);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
