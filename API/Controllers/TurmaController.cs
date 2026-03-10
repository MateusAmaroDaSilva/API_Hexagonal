using ApiHexagonal.Bussiness.DTOs;
using ApiHexagonal.Bussiness.Entities;
using ApiHexagonal.Bussiness.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ApiHexagonal.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaService _service;
        public TurmaController(ITurmaService service)
        {
            _service = service;
        }

        [HttpGet("GetClasses/{Id}")]
        public IActionResult GetClassroom(int Id)
        {
            Turma Turma = _service.GetClassroom(Id);

            if(Turma == null)
            {
                return NotFound("Classe não Encontrado");
            }

            return Ok(Turma);
        }

        [HttpGet("ListClasses")]
        public IActionResult ListClassroom()
        {
            List<Turma> Turma = _service.ListClassroom();
            return Ok(Turma);
        }

        [HttpPost("PostClasses")]
        public async Task<IActionResult> PostClassroom(TurmaDTO TurmaDTO)
        {
            try
            {
                await _service.Registrar(TurmaDTO);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
