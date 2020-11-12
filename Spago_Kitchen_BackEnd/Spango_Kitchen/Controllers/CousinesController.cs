using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spango_Kitchen.Model;

namespace Spango_Kitchen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CousinesController : ControllerBase
    {
        private readonly Spango_Context _context;

        public CousinesController(Spango_Context context)
        {
            _context = context;
        }

        // GET: api/Cousines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cousine>>> GetCousine()
        {
            return await _context.Cousine.ToListAsync();
        }

        // GET: api/Cousines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cousine>> GetCousine(int id)
        {
            var cousine = await _context.Cousine.FindAsync(id);

            if (cousine == null)
            {
                return NotFound();
            }

            return cousine;
        }

        // PUT: api/Cousines/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCousine(int id, Cousine cousine)
        {
            if (id != cousine.Id)
            {
                return BadRequest();
            }

            _context.Entry(cousine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CousineExists(id))
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

        // POST: api/Cousines
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cousine>> PostCousine(Cousine cousine)
        {
            _context.Cousine.Add(cousine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCousine", new { id = cousine.Id }, cousine);
        }

        // DELETE: api/Cousines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cousine>> DeleteCousine(int id)
        {
            var cousine = await _context.Cousine.FindAsync(id);
            if (cousine == null)
            {
                return NotFound();
            }

            _context.Cousine.Remove(cousine);
            await _context.SaveChangesAsync();

            return cousine;
        }

        private bool CousineExists(int id)
        {
            return _context.Cousine.Any(e => e.Id == id);
        }
    }
}
