using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_vivaviatravel2.Models;
using api_vivaviatravel2.Context;

namespace api_vivaviatravel2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ClienteController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/ClienteModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteModel>>> GetClientes()
        {
          if (_context.Clientes == null)
          {
              return NotFound();
          }
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteModel>> GetClienteModel(int id)
        {
          if (_context.Clientes == null)
          {
              return NotFound();
          }
            var clienteModel = await _context.Clientes.FindAsync(id);

            if (clienteModel == null)
            {
                return NotFound();
            }

            return clienteModel;
        }

        // PUT: api/Cliente/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClienteModel(int id, ClienteModel clienteModel)
        {
            if (id != clienteModel.ClienteId)
            {
                return BadRequest();
            }

            _context.Entry(clienteModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteModelExists(id))
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

        // POST: api/Cliente
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClienteModel>> PostClienteModel(ClienteModel clienteModel)
        {
          if (_context.Clientes == null)
          {
              return Problem("Entity set 'ApiDbContext.Clientes'  is null.");
          }
            _context.Clientes.Add(clienteModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClienteModel", new { id = clienteModel.ClienteId }, clienteModel);
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClienteModel(int id)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var clienteModel = await _context.Clientes.FindAsync(id);
            if (clienteModel == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(clienteModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteModelExists(int id)
        {
            return (_context.Clientes?.Any(e => e.ClienteId == id)).GetValueOrDefault();
        }
    }
}
