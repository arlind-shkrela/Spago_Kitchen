using Microsoft.AspNetCore.Mvc;
using Spango_Kitchen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spango_Kitchen.Services
{
    public interface IIngredient
    {
        Task<ActionResult<IEnumerable<Ingredient>>> GetIngredients();
        Task<ActionResult<Ingredient>> GetIngredients(int id);
        Task<IActionResult> PutIngredients(int id, Ingredient ingredients);
        Task<ActionResult<Ingredient>> PostIngredients(Ingredient ingredients);
        Task<ActionResult<Ingredient>> DeleteIngredients(int id);
        Task<bool> IngredientsExists(int id);
    }
}
