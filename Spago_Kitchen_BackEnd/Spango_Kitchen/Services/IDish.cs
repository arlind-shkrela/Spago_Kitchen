using Microsoft.AspNetCore.Mvc;
using Spango_Kitchen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spango_Kitchen.Services
{
    public interface IDish
    {
        Task<ActionResult<IEnumerable<Dish>>> GetDish();
        Task<ActionResult<Dish>> GetDish(int id);
        Task<IActionResult> PutDish(int id, Dish dish);
        Task<ActionResult<Dish>> PostDish(Dish dish);
        Task<ActionResult<Dish>> DeleteDish(int id);
    }
}
