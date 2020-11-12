using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spango_Kitchen.Model
{
    public class Spango_Context : DbContext
    {
        public Spango_Context(DbContextOptions<Spango_Context> options)
            : base(options)
        {
        }

        
        public DbSet<Category> Category { get; set; }
        public DbSet<CookingTime> CookingTime { get; set; }
        public DbSet<Cousine> Cousine { get; set; }
        public DbSet<Dish> Dish { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredientsDetails> DishIngredientsDetails { get; set; }

    }
}
