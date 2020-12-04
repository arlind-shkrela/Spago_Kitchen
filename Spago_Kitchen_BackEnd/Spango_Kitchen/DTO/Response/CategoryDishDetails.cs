using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spango_Kitchen.DTO.Response
{
    public class CategoryDishDetails
    {
        public int Id { get; set; }
        public string DishName { get; set; }

        public string CookingTime { get; set; }
        public string CousineName { get; set; }
    }
}
