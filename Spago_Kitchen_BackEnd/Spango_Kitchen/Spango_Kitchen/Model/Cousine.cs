using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spango_Kitchen.Model
{
    public class Cousine
    {
        public int Id { get; set; }

        public string CousineName { get; set; }
        public virtual ICollection<Dish> Dish { get; set; }
        public bool Deleted { get; set; } = false;

    }
}
