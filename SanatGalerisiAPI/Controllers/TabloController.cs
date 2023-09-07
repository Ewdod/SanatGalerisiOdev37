using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SanatGalerisiAPI.Data;

namespace SanatGalerisiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabloController : ControllerBase
    {
        private readonly TabloDbContext _context;

        public TabloController(TabloDbContext context)
        {
            _context = context;
        }

        // GET: api/Tabloes
        [HttpGet("Tablolar")]
        public async Task<ActionResult<IEnumerable<Tablo>>> GetTablolar()
        {
          if (_context.Tablolar == null)
          {
              return NotFound();
          }
            return await _context.Tablolar.ToListAsync();
        }

        // GET: api/Tabloes/5
        [HttpGet("TabloById")]
        public async Task<ActionResult<Tablo>> GetTablo(int id)
        {
          if (_context.Tablolar == null)
          {
              return NotFound();
          }
            var tablo = await _context.Tablolar.FindAsync(id);

            if (tablo == null)
            {
                return NotFound();
            }

            return tablo;
        }

        // PUT: api/Tabloes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTablo(int id, Tablo tablo)
        {
            if (id != tablo.Id)
            {
                return BadRequest();
            }

            _context.Entry(tablo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TabloExists(id))
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

        // POST: api/Tabloes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tablo>> PostTablo(Tablo tablo)
        {
          if (_context.Tablolar == null)
          {
              return Problem("Entity set 'TabloDbContext.Tablolar'  is null.");
          }
            _context.Tablolar.Add(tablo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTablo", new { id = tablo.Id }, tablo);
        }

        // DELETE: api/Tabloes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTablo(int id)
        {
            if (_context.Tablolar == null)
            {
                return NotFound();
            }
            var tablo = await _context.Tablolar.FindAsync(id);
            if (tablo == null)
            {
                return NotFound();
            }

            _context.Tablolar.Remove(tablo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TabloExists(int id)
        {
            return (_context.Tablolar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
