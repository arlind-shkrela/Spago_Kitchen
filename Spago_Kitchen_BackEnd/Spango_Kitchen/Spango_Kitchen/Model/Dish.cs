using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spango_Kitchen.Model
{
    public class Dish
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int CousineId { get; set; }
        public virtual Cousine Cousine{ get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }

        public double Price { get; set; }
        public int CookingTimeId { get; set; }
        public virtual CookingTime CookingTime { get; set; }



        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public ICollection<DishIngredientsDetails> DishIngredientsDetails { get; set; }
        public bool Deleted { get; set; } = false;
    }
}
