using Microsoft.AspNetCore.Mvc;
using Spango_Kitchen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spango_Kitchen.Services
{
    public interface ICategory
    {
        Task<ActionResult<IEnumerable<Category>>> GetCategory();

        Task<ActionResult<Category>> GetCategory(int id);


        Task<IActionResult> PutCategory(int id, Category category);

        Task<ActionResult<Category>> PostCategory(Category category);
        Task<ActionResult<Category>> DeleteCategory(int id);

        Task<bool> CategoryExists(int id);
    }
}
