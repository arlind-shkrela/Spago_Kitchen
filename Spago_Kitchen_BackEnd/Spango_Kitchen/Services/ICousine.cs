using Microsoft.AspNetCore.Mvc;
using Spango_Kitchen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spango_Kitchen.Services
{
    public interface ICousine
    {
        Task<ActionResult<IEnumerable<Cousine>>> GetCousine();
        Task<ActionResult<Cousine>> GetCousine(int id);
        Task<IActionResult> PutCousine(int id, Cousine cousine);
        Task<ActionResult<Cousine>> PostCousine(Cousine cousine);
        Task<ActionResult<Cousine>> DeleteCousine(int id);

        Task<bool> CousineExists(int id);
    }
}
