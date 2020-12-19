using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spango_Kitchen.DatabaseContext;
using Spango_Kitchen.Model;
using Spango_Kitchen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spango_Kitchen.ServicesImplementations
{
    public class Ingredient : IIngredient
    {

        private readonly Spago_Context _context;

        public Ingredient(Spago_Context context)
        {
            _context = context;
        }

        public async Task<ActionResult<Model.Ingredient>> DeleteIngredients(int id)
        {
            var ingredients = await _context.Ingredients.FindAsync(id);
            if (ingredients == null)
            {
                return null;
            }
            ingredients.Deleted = true;
            await _context.SaveChangesAsync();
            //_context.Ingredients.Remove(ingredients);
            await _context.SaveChangesAsync();

            return ingredients;
        }

        public async Task<ActionResult<IEnumerable<Model.Ingredient>>> GetIngredients()
        {
            return await _context.Ingredients.ToListAsync();
        }

        public async Task<ActionResult<Model.Ingredient>> GetIngredients(int id)
        {
            var ingredients = await _context.Ingredients.FindAsync(id);

            if (ingredients == null)
            {
                return null;
            }

            return ingredients;
        }

        public async Task<ActionResult<Model.Ingredient>> PostIngredients(Model.Ingredient ingredients)
        {
            _context.Ingredients.Add(ingredients);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<IActionResult> PutIngredients(int id, Model.Ingredient ingredients)
        {
            if (id != ingredients.Id)
            {
                return null;
            }

            _context.Entry(ingredients).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await IngredientsExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return null;
        }


        public async Task<bool> IngredientsExists(int id)
        {
            return await _context.Ingredients.AnyAsync(e => e.Id == id);
        }
    }
}
