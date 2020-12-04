using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spango_Kitchen.DatabaseContext;
using Spango_Kitchen.DTO.Response;
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
        private readonly Spago_Context _context;
        private readonly IMapper _mapper;

        public Dish(Spago_Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<Model.Dish>>> GetDish()
        {
            return await _context.Dish.ToListAsync();
        }
        public async Task<ActionResult<Model.Dish>> GetDishById(int id)
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
                //
            }

            _context.Entry(dish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DishExists(id))
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
        public async Task<ActionResult<Model.Dish>> DeleteDish(int id)
        {
            var dish = await _context.Dish.FindAsync(id);
            if (dish == null)
            {
                return null;
            }

            _context.Dish.Remove(dish);
            await _context.SaveChangesAsync();

            return dish;
        }


        public async Task<bool> DishExists(int id)
        {
            return await _context.Dish.AnyAsync(e => e.Id == id);
        }

        public async Task<CategoriesDishesResponseDTO> GetDishListByCategoryId(int categoryId)
        {
            var queryResponse = await _context.Dish.Include(s => s.Category).Include(s => s.Cousine).Include(s=>s.CookingTime).Where(s => s.CategoryId == categoryId).ToListAsync();

            CategoriesDishesResponseDTO response = new CategoriesDishesResponseDTO();
            response = _mapper.Map<CategoriesDishesResponseDTO>(queryResponse.FirstOrDefault());
            response.Dishes = _mapper.Map<List<CategoryDishDetails>>(queryResponse);

            return response;


        }
    }
}
