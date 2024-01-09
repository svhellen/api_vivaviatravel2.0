using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_vivaviatravel2.Context;
using api_vivaviatravel2.Models;

namespace api_vivaviatravel2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinoController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public DestinoController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Destino
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DestinoModel>>> GetDestinos()
        {
            var destinos = await _context.Destinos.ToListAsync();

            foreach (var destino in destinos)
            {
                if (destino.ImagemUrl == null)
                {
                    destino.ImagemUrl = "https://picsum.photos/500/300/?blur=10";
                }
            }

            return destinos;
        }


        // GET: api/Destino/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DestinoModel>> GetDestinoModel(int id)
        {
            var destinoModel = await _context.Destinos.FindAsync(id);

            if (destinoModel == null)
            {
                return NotFound();
            }

            return destinoModel;
        }

        // PUT: api/Destino/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDestinoModel(int id, DestinoModel destinoModel)
        {
            if (id != destinoModel.DestinoId)
            {
                return BadRequest();
            }

            _context.Entry(destinoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinoModelExists(id))
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

        // POST: api/Destino
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DestinoModel>> PostDestinoModel(DestinoModel destinoModel)
        {
            _context.Destinos.Add(destinoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDestinoModel", new { id = destinoModel.DestinoId }, destinoModel);
        }

        // DELETE: api/Destino/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestinoModel(int id)
        {
            var destinoModel = await _context.Destinos.FindAsync(id);
            if (destinoModel == null)
            {
                return NotFound();
            }

            _context.Destinos.Remove(destinoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DestinoModelExists(int id)
        {
            return _context.Destinos.Any(e => e.DestinoId == id);
        }
    }
}
