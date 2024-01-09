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
    public class PassagemController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PassagemController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/PassagemModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PassagemModel>>> GetPassagens()
        {
          if (_context.Passagens == null)
          {
              return NotFound();
          }
            return await _context.Passagens.ToListAsync();
        }

        // GET: api/PassagemModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PassagemModel>> GetPassagemModel(int id)
        {
          if (_context.Passagens == null)
          {
              return NotFound();
          }
            var passagemModel = await _context.Passagens.FindAsync(id);

            if (passagemModel == null)
            {
                return NotFound();
            }

            return passagemModel;
        }

        // PUT: api/PassagemModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassagemModel(int id, PassagemModel passagemModel)
        {
            if (id != passagemModel.PassagemId)
            {
                return BadRequest();
            }

            _context.Entry(passagemModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassagemModelExists(id))
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

        // POST: api/PassagemModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PassagemModel>> PostPassagemModel(PassagemModel passagemModel)
        {
          if (_context.Passagens == null)
          {
              return Problem("Entity set 'ApiDbContext.Passagens'  is null.");
          }
            _context.Passagens.Add(passagemModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassagemModel", new { id = passagemModel.PassagemId }, passagemModel);
        }

        // DELETE: api/PassagemModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassagemModel(int id)
        {
            if (_context.Passagens == null)
            {
                return NotFound();
            }
            var passagemModel = await _context.Passagens.FindAsync(id);
            if (passagemModel == null)
            {
                return NotFound();
            }

            _context.Passagens.Remove(passagemModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassagemModelExists(int id)
        {
            return (_context.Passagens?.Any(e => e.PassagemId == id)).GetValueOrDefault();
        }
    }
}
