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
    public class CookingTime : ICookingTime
    {
        private readonly Spango_Context _context;

        public CookingTime(Spango_Context context)
        {
            _context = context;
        }


        public async Task<ActionResult<IEnumerable<Model.CookingTime>>> GetCookingTime()
        {
            return await _context.CookingTime.ToListAsync();
        }

        public async Task<ActionResult<Model.CookingTime>> GetCookingTime(int id)
        {
            var cookingTime = await _context.CookingTime.FindAsync(id);

            if (cookingTime == null)
            {
                return null;
            }

            return cookingTime;
        }

        public async Task<ActionResult<Model.CookingTime>> PostCookingTime(Model.CookingTime cookingTime)
        {
            _context.CookingTime.Add(cookingTime);
            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<IActionResult> PutCookingTime(int id, Model.CookingTime cookingTime)
        {
            if (id != cookingTime.Id)
            {
                return null;
            }

            _context.Entry(cookingTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CookingTimeExists(id))
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
        public async Task<ActionResult<Model.CookingTime>> DeleteCookingTime(int id)
        {
            var cookingTime = await _context.CookingTime.FindAsync(id);
            if (cookingTime == null)
            {
                return null;
            }

            _context.CookingTime.Remove(cookingTime);
            await _context.SaveChangesAsync();

            return cookingTime;
        }


        public async Task<bool> CookingTimeExists(int id)
        {
            return await _context.CookingTime.AnyAsync(e => e.Id == id);
        }
    }
}
