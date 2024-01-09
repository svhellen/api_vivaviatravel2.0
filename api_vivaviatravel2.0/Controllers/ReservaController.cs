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
    public class ReservaController : ControllerBase
    {
        private readonly ApiDbContext _context;
 /*       private ClienteModel cliente;
        private PassagemModel passagem;
*/

        public ReservaController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Reserva
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaModel>>> GetReservas()
        {
            
           var Reservas = await _context.Reservas
            .Include(r => r.Cliente) 
            .Include(r => r.Passagem)
            .Include(r => r.Hospedagem)
            .Include(r => r.Pacote)
            .ToListAsync();

            return Reservas;
        }

        // GET: api/Reserva/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaModel>> GetReservaModel(int id)
        {
            var reservaModel = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Passagem)
                .Include(r => r.Hospedagem)
                .Include(r => r.Pacote)
                .FirstOrDefaultAsync(r => r.ReservaId == id);

            if (reservaModel == null)
            {
                return NotFound();
            }

            return reservaModel;
        }

        // PUT: api/Reserva/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservaModel(int id, ReservaModel reservaModel)/*, int clienteId, int passagemId*/
        {
            if (id != reservaModel.ReservaId)
            {
                return BadRequest();
            }

            /*reservaModel.Cliente.ClienteId = clienteId;
            reservaModel.Passagem.PassagemId = passagemId;*/
            _context.Entry(reservaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaModelExists(id))
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

        // POST: api/Reserva
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReservaModel>> PostReservaModel(ReservaModel reservaModel)
        {
            _context.Reservas.Add(reservaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservaModel", new { id = reservaModel.ReservaId }, reservaModel);
        }

        // DELETE: api/Reserva/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservaModel(int id)
        {
            var reservaModel = await _context.Reservas.FindAsync(id);
            if (reservaModel == null)
            {
                return NotFound();
            }

            _context.Reservas.Remove(reservaModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservaModelExists(int id)
        {
            return _context.Reservas.Any(e => e.ReservaId == id);
        }
    }
}
