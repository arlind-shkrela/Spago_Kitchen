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
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredient _ingredient;

        public IngredientsController(IIngredient ingredient)
        {
            _ingredient = ingredient;
        }

        // GET: api/Ingredients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredients()
        {
            return await _ingredient.GetIngredients();
        }

        // GET: api/Ingredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredient>> GetIngredients(int id)
        {
            var ingredients = await _ingredient.GetIngredients(id);

            if (ingredients == null)
            {
                return NotFound();
            }

            return ingredients;
        }

        // PUT: api/Ingredients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredients(int id, Ingredient ingredients)
        {
            if (id != ingredients.Id)
            {
                return BadRequest();
            }
            try
            {
                await _ingredient.PutIngredients(id,ingredients);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _ingredient.IngredientsExists(id))
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

        // POST: api/Ingredients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ingredient>> PostIngredients(Ingredient ingredients)
        {
            await _ingredient.PostIngredients(ingredients);
            return CreatedAtAction("GetIngredients", new { id = ingredients.Id }, ingredients);
        }

        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ingredient>> DeleteIngredients(int id)
        {
            var ingredients = await _ingredient.GetIngredients(id);
            if (ingredients == null)
            {
                return NotFound();
            }

            await _ingredient.DeleteIngredients(ingredients.Value.Id);
            return ingredients;
        }
    }
}
