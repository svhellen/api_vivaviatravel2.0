using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_vivaviatravel2.Context;
using api_vivaviatravel2.Models;

namespace api_vivaviatravel2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacoteController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PacoteController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Pacote
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PacoteModel>>> GetPacotes()
        {
            /*return await _context.Pacotes.ToListAsync();*/
            var Pacotes = await _context.Pacotes
             .Include(p => p.Hospedagem)
             .Include(p => p.Passagem)
             .ToListAsync();

            return Pacotes;
        }

        // GET: api/Pacote/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PacoteModel>> GetPacoteModel(int id)
        {
            /*var pacoteModel = await _context.Pacotes.FindAsync(id);*/
            var pacoteModel = await _context.Pacotes
                .Include(p => p.Hospedagem)
                .Include(p => p.Passagem)
                .FirstOrDefaultAsync(p => p.PacoteId == id);

            if (pacoteModel == null)
            {
                return NotFound();
            }

            return pacoteModel;
        }

        // PUT: api/Pacote/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPacoteModel(int id, PacoteModel pacoteModel)
        {
            if (id != pacoteModel.PacoteId)
            {
                return BadRequest();
            }

            _context.Entry(pacoteModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacoteModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pacote
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PacoteModel>> PostPacoteModel(PacoteModel pacoteModel)
        {
            _context.Pacotes.Add(pacoteModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPacoteModel", new { id = pacoteModel.PacoteId }, pacoteModel);
        }

        // DELETE: api/Pacote/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePacoteModel(int id)
        {
            var pacoteModel = await _context.Pacotes.FindAsync(id);
            if (pacoteModel == null)
            {
                return NotFound();
            }

            _context.Pacotes.Remove(pacoteModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PacoteModelExists(int id)
        {
            return _context.Pacotes.Any(e => e.PacoteId == id);
        }
    }
}
