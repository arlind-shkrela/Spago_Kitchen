using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spango_Kitchen.Model;
using Spango_Kitchen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spango_Kitchen.ServicesImplementations
{
    public class Dish : IDish
    {
        private readonly Spango_Context _context;

        public Dish(Spango_Context context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Model.Dish>>> GetDish()
        {
            return await _context.Dish.ToListAsync();
        }
        public async Task<ActionResult<Model.Dish>> GetDish(int id)
        {
            var dish = await _context.Dish.FindAsync(id);

            if (dish == null)
            {
                //return NotFound();
            }

            return dish;
        }
        public async Task<ActionResult<Model.Dish>> PostDish(Model.Dish dish)
        {
            _context.Dish.Add(dish);
            await _context.SaveChangesAsync();

            return null;
        }
        public async Task<IActionResult> PutDish(int id, Model.Dish dish)
        {
            if (id != dish.Id)
            {
                //return BadRequest();
            }

            _context.Entry(dish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishExists(id))
                {
                  //  return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return null;
        }
        public async Task<ActionResult<Model.Dish>> DeleteDish(int id)
        {
            var dish = await _context.Dish.FindAsync(id);
            if (dish == null)
            {
                //return NotFound();
            }

            _context.Dish.Remove(dish);
            await _context.SaveChangesAsync();

            return dish;
        }


        private bool DishExists(int id)
        {
            return _context.Dish.Any(e => e.Id == id);
        }
    }
}
