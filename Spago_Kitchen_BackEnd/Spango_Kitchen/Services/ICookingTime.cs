using Microsoft.AspNetCore.Mvc;
using Spango_Kitchen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spango_Kitchen.Services
{
    public interface ICookingTime
    {
        Task<ActionResult<IEnumerable<CookingTime>>> GetCookingTime();
        Task<ActionResult<CookingTime>> GetCookingTime(int id);
        Task<IActionResult> PutCookingTime(int id, CookingTime cookingTime);
        Task<ActionResult<CookingTime>> PostCookingTime(CookingTime cookingTime);
        Task<ActionResult<CookingTime>> DeleteCookingTime(int id);

        Task<bool> CookingTimeExists(int id);
    }
}
