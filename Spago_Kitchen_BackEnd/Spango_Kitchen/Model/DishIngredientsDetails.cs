using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spango_Kitchen.Model
{
    public class DishIngredientsDetails
    {
        public int Id { get; set; }

        public int DishId { get; set; }
        public virtual Dish Dish { get; set; }

        public int IngredientsId { get; set; }
        public virtual Ingredients Ingredients { get; set; }
    }

}
