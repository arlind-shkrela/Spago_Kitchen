using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spango_Kitchen.Model
{
    public class CookingTime
    {
        public int Id { get; set; }

        public string Time { get; set; }

        public virtual ICollection<Dish> Dish { get; set; }
        public bool Deleted { get; set; } = false;

    }
}
