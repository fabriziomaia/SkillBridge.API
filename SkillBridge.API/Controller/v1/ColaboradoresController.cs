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
    public class ColaboradoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ColaboradoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/v1/Colaboradores
        /// <summary>
        /// Lista todos os Colaboradores cadastrados.
        /// </summary>
        /// <returns>Uma lista de colaboradores, incluindo seus planos de desenvolvimento.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colaborador>>> GetColaboradores()
        {
            return await _context.Colaboradores.Include(c => c.Planos).ToListAsync();
        }

        // GET: api/v1/Colaboradores/{id}
        /// <summary>
        /// Busca um Colaborador específico pelo seu ID.
        /// </summary>
        /// <param name="id">O ID (GUID) do colaborador a ser buscado.</param>
        /// <response code="200">Retorna o colaborador encontrado.</response>
        /// <response code="404">Se não for encontrado um colaborador com o ID fornecido.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Colaborador>> GetColaborador(Guid id)
        {
            var colaborador = await _context.Colaboradores
                .Include(c => c.Planos)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (colaborador == null)
            {
                return NotFound();
            }

            return Ok(colaborador);
        }

        // POST: api/v1/Colaboradores
        /// <summary>
        /// Cria um novo Colaborador.
        /// </summary>
        /// <param name="colaborador">O objeto do colaborador a ser criado.</param>
        /// <response code="201">Retorna o colaborador recém-criado com sucesso.</response>
        /// <response code="400">Se o objeto do colaborador for inválido.</response>
        [HttpPost]
        public async Task<ActionResult<Colaborador>> CreateColaborador(Colaborador colaborador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            colaborador.Id = Guid.NewGuid();
            _context.Colaboradores.Add(colaborador);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetColaborador), new { id = colaborador.Id, version = "1.0" }, colaborador);
        }

    }
}