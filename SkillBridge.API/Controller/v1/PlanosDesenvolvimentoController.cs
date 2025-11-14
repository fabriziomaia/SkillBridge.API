using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillBridge.API.Data;
using SkillBridge.API.Models;

namespace SkillBridge.API.Controllers.v1
{
    [ApiController]
    [Asp.Versioning.ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PlanosDesenvolvimentoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlanosDesenvolvimentoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/v1/PlanosDesenvolvimento
        /// <summary>
        /// Lista todos os Planos de Desenvolvimento.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PlanoDesenvolvimento>>> GetPlanos()
        {
            return await _context.PlanosDesenvolvimento.ToListAsync();
        }

        // GET: api/v1/PlanosDesenvolvimento/{id}
        /// <summary>
        /// Busca um Plano de Desenvolvimento específico pelo seu ID.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PlanoDesenvolvimento>> GetPlano(Guid id)
        {
            var plano = await _context.PlanosDesenvolvimento.FindAsync(id);

            if (plano == null)
            {
                return NotFound(new { Mensagem = "Plano não encontrado" });
            }

            return Ok(plano);
        }

        // POST: api/v1/PlanosDesenvolvimento
        /// <summary>
        /// Cria um novo Plano de Desenvolvimento (PDI).
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PlanoDesenvolvimento>> CreatePlano(PlanoDesenvolvimento plano)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            plano.Id = Guid.NewGuid();
            plano.DataInicio = DateTime.UtcNow;

            _context.PlanosDesenvolvimento.Add(plano);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlano), new { id = plano.Id, version = "1.0" }, plano);
        }

        // PUT: api/v1/PlanosDesenvolvimento/{id}
        /// <summary>
        /// Atualiza um Plano de Desenvolvimento existente.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePlano(Guid id, PlanoDesenvolvimento plano)
        {
            if (id != plano.Id)
            {
                return BadRequest(new { Mensagem = "IDs de rota e corpo não conferem" });
            }

            var planoExistente = await _context.PlanosDesenvolvimento.FindAsync(id);
            if (planoExistente == null)
            {
                return NotFound(new { Mensagem = "Plano não encontrado para atualização" });
            }

            // Atualiza o objeto existente com os novos valores
            _context.Entry(planoExistente).CurrentValues.SetValues(plano);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.PlanosDesenvolvimento.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/v1/PlanosDesenvolvimento/{id}
        /// <summary>
        /// Apaga um Plano de Desenvolvimento pelo seu ID.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePlano(Guid id)
        {
            var plano = await _context.PlanosDesenvolvimento.FindAsync(id);
            if (plano == null)
            {
                return NotFound(new { Mensagem = "Plano não encontrado" });
            }

            _context.PlanosDesenvolvimento.Remove(plano);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}