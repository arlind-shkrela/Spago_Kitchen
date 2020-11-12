using Microsoft.EntityFrameworkCore;
using Spango_Kitchen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spango_Kitchen.DatabaseContext
{
    public class Spago_Context : DbContext
    {
        public Spago_Context(DbContextOptions<Spago_Context> options)
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
