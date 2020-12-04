using AutoMapper;
using Spango_Kitchen.DTO.Response;
using Spango_Kitchen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spango_Kitchen.Profiles
{
    public class CategoryDishes : Profile
    {
        public CategoryDishes()
        {
            CreateMap<Dish, CategoriesDishesResponseDTO>()
           .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
           .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
 
        }
    }
}
