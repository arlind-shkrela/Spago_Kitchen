using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spango_Kitchen.Model;
using Spango_Kitchen.Services;

namespace Spango_Kitchen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CousinesController : ControllerBase
    {
        private readonly ICousine _cousine;

        public CousinesController(ICousine cousine)
        {
            _cousine = cousine;
        }

        // GET: api/Cousines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cousine>>> GetCousine()
        {
            return await _cousine.GetCousine();
        }

        // GET: api/Cousines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cousine>> GetCousine(int id)
        {
            var cousine = await _cousine.GetCousine(id);

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
            try
            {
                await _cousine.PutCousine(id,cousine);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await _cousine.CousineExists(id))
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
            await _cousine.PostCousine(cousine);
            return CreatedAtAction("GetCousine", new { id = cousine.Id }, cousine);
        }

        // DELETE: api/Cousines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cousine>> DeleteCousine(int id)
        {
            var cousine = await _cousine.GetCousine(id);
            if (cousine == null)
            {
                return NotFound();
            }

            await _cousine.DeleteCousine(cousine.Value.Id);
            return cousine;
        }
    }
}
