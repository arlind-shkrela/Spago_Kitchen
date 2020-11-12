using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spango_Kitchen.Model
{
    public class Ingredient
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string IngredientName { get; set; }

        public virtual ICollection<DishIngredientsDetails> DishIngredientsDetails { get; set; }
        public bool Deleted { get; set; } = false;

    }
}
