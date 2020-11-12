using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spango_Kitchen.Model
{
    public class Cousine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CousineName { get; set; }
        public virtual ICollection<Dish> Dish { get; set; }
        public bool Deleted { get; set; } = false;

    }
}
