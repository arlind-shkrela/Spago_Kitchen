using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spango_Kitchen.Model
{
    public class Ingredients
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }

        public virtual ICollection<DishIngredientsDetails> DishIngredientsDetails { get; set; }
        public bool Deleted { get; set; } = false;

    }
}
