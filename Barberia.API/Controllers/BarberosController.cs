using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Barberia.API.Data;
using Barberia.Modelos;

namespace Barberia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarberosController : ControllerBase
    {
        private readonly BarberiaAPIContext _context;

        public BarberosController(BarberiaAPIContext context)
        {
            _context = context;
        }

        // GET: api/Barberos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Barbero>>> GetBarbero()
        {
            return await _context.Barbero.ToListAsync();
        }

        // GET: api/Barberos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Barbero>> GetBarbero(int id)
        {
            var barbero = await _context.Barbero.FindAsync(id);

            if (barbero == null)
            {
                return NotFound();
            }

            return barbero;
        }

        // PUT: api/Barberos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBarbero(int id, Barbero barbero)
        {
            if (id != barbero.Id)
            {
                return BadRequest();
            }

            _context.Entry(barbero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarberoExists(id))
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

        // POST: api/Barberos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Barbero>> PostBarbero(Barbero barbero)
        {
            _context.Barbero.Add(barbero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBarbero", new { id = barbero.Id }, barbero);
        }

        // DELETE: api/Barberos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarbero(int id)
        {
            var barbero = await _context.Barbero.FindAsync(id);
            if (barbero == null)
            {
                return NotFound();
            }

            _context.Barbero.Remove(barbero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BarberoExists(int id)
        {
            return _context.Barbero.Any(e => e.Id == id);
        }
    }
}
