using Microsoft.AspNetCore.Mvc;
using Spango_Kitchen.Services;
using Spango_Kitchen.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spango_Kitchen.DatabaseContext;

namespace Spango_Kitchen.ServicesImplementations
{
    public class Category : ICategory
    {
        private readonly Spago_Context _context;

        public Category(Spago_Context context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Model.Category>>> GetCategory()
        {
            return await _context.Category.ToListAsync();
        }
        public async Task<ActionResult<Model.Category>> GetCategory(int id)
        {
            var category = await _context.Category.FindAsync(id);

            if (category == null)
            {
               // return NotFound();
            }

            return category;
        }
        public async Task<ActionResult<Model.Category>> PostCategory(Model.Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetCategory", new { id = category.Id }, category);
            return null;
        }
        public async Task<IActionResult> PutCategory(int id, Model.Category category)
        {
            if (id != category.Id)
            {
                //return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CategoryExists(id))
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

        public async Task<ActionResult<Model.Category>> DeleteCategory(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                //return NotFound();
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<bool> CategoryExists(int id)
        {
            return await _context.Category.AnyAsync(e => e.Id == id);
        }

    }
}
