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
    public class CookingTimesController : ControllerBase
    {
        private readonly ICookingTime _cookingTime;

        public CookingTimesController(ICookingTime cookingTime)
        {
            _cookingTime = cookingTime;
        }

        // GET: api/CookingTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CookingTime>>> GetCookingTime()
        {
            return await _cookingTime.GetCookingTime();
        }

        // GET: api/CookingTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CookingTime>> GetCookingTime(int id)
        {
            var cookingTime = await _cookingTime.GetCookingTime(id);

            if (cookingTime == null)
            {
                return NotFound();
            }

            return cookingTime;
        }

        // PUT: api/CookingTimes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCookingTime(int id, CookingTime cookingTime)
        {
            if (id != cookingTime.Id)
            {
                return BadRequest();
            }
            try
            {
                await _cookingTime.PutCookingTime(id, cookingTime);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await _cookingTime.CookingTimeExists(id))
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

        // POST: api/CookingTimes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CookingTime>> PostCookingTime(CookingTime cookingTime)
        {
            await _cookingTime.PostCookingTime(cookingTime);
            return CreatedAtAction("GetCookingTime", new { id = cookingTime.Id }, cookingTime);
        }

        // DELETE: api/CookingTimes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CookingTime>> DeleteCookingTime(int id)
        {
            var cookingTime = await _cookingTime.GetCookingTime(id);
            if (cookingTime == null)
            {
                return NotFound();
            }

            await _cookingTime.DeleteCookingTime(id);
            return cookingTime;
        }

       
    }
}
