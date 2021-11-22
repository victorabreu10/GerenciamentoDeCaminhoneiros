using CadastroCaminhoneiro.Models;
using CadastroCaminhoneiro.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroCaminhoneiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly ICadastroRepository _cadastroRepository;

        public CadastroController(ICadastroRepository cadastroRepository)
        {
            _cadastroRepository = cadastroRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<CadastroModel>> BuscarMotorista()
        {
            return await _cadastroRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CadastroModel>> BuscarMotoristaPorId(int id)
        {
            return await _cadastroRepository.Get(id); 
        }

        [HttpPost] 
        public async Task<ActionResult<CadastroModel>>CriarMotorista([FromBody] CadastroModel motorista)
        {
            var criarbook = await _cadastroRepository.Create(motorista);
            return CreatedAtAction(nameof(BuscarMotoristaPorId), new { id = criarbook.Id }, criarbook);
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarMotorista(int id, [FromBody] CadastroModel motorista)
        {
            if(id != motorista.Id)
            {
                return BadRequest();
            }

            await _cadastroRepository.Update(motorista);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarMotorista (int id)
        {
            var motoristaToDelete = await _cadastroRepository.Get(id);
            if (motoristaToDelete == null)
                return NotFound();

            await _cadastroRepository.Delete(motoristaToDelete.Id);
            return NoContent();
        }
    }
}
