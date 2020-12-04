using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spango_Kitchen.DTO.Response
{
    public class CategoriesDishesResponseDTO
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
        public List<CategoryDishDetails> Dishes { get; set; }
    }
}
