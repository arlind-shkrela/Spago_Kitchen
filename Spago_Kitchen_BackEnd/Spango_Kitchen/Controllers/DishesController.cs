using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spango_Kitchen.DTO.Response;
using Spango_Kitchen.Model;
using Spango_Kitchen.Services;

namespace Spango_Kitchen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly IDish _dish;


        public DishesController(IDish dish)
        {
            _dish = dish;
        }

        // GET: api/Dishes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dish>>> GetDish()
        {
            return await _dish.GetDish();
        }

        // GET: api/Dishes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dish>> GetDish(int id)
        {
            var dish = await _dish.GetDishById(id);

            if (dish == null)
            {
                return NotFound();
            }

            return dish;
        }

        // GET: api/CategoryId/Dishes
        [HttpGet]
        [Route("/api/Category/{categoryId}/Dishes")]
        public async Task<CategoriesDishesResponseDTO> GetDishCategory(int categoryId)
        {
            var response = await _dish.GetDishListByCategoryId(categoryId);
            return response;
        }

        // PUT: api/Dishes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDish(int id, Dish dish)
        {
            if (id != dish.Id)
            {
                return BadRequest();
            }

            try
            {
                await _dish.PutDish(id,dish);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await _dish.DishExists(id))
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

        // POST: api/Dishes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Dish>> PostDish(Dish dish)
        {
            await _dish.PostDish(dish);
            return CreatedAtAction("GetDish", new { id = dish.Id }, dish);
        }

        // DELETE: api/Dishes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dish>> DeleteDish(int id)
        {
            var dish = await _dish.GetDishById(id);
            if (dish == null)
            {
                return NotFound();
            }

            await _dish.DeleteDish(id);
            return dish;
        }
    }
}
