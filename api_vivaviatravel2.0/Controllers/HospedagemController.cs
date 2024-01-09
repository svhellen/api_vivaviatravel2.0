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
    public class HospedagemController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public HospedagemController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Hospedagem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospedagemModel>>> GetHospedagens()
        {
            return await _context.Hospedagens.ToListAsync();
        }

        // GET: api/Hospedagem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospedagemModel>> GetHospedagemModel(int id)
        {
            var hospedagemModel = await _context.Hospedagens.FindAsync(id);

            if (hospedagemModel == null)
            {
                return NotFound();
            }

            return hospedagemModel;
        }

        // PUT: api/Hospedagem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospedagemModel(int id, HospedagemModel hospedagemModel)
        {
            if (id != hospedagemModel.HospedagemId)
            {
                return BadRequest();
            }

            _context.Entry(hospedagemModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospedagemModelExists(id))
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

        // POST: api/Hospedagem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HospedagemModel>> PostHospedagemModel(HospedagemModel hospedagemModel)
        {
            _context.Hospedagens.Add(hospedagemModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospedagemModel", new { id = hospedagemModel.HospedagemId }, hospedagemModel);
        }

        // DELETE: api/Hospedagem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHospedagemModel(int id)
        {
            var hospedagemModel = await _context.Hospedagens.FindAsync(id);
            if (hospedagemModel == null)
            {
                return NotFound();
            }

            _context.Hospedagens.Remove(hospedagemModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HospedagemModelExists(int id)
        {
            return _context.Hospedagens.Any(e => e.HospedagemId == id);
        }
    }
}
