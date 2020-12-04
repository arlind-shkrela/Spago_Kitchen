using AutoMapper;
using Spango_Kitchen.DTO.Response;
using Spango_Kitchen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spango_Kitchen.Profiles
{
    public class CategoryDishesProfile : Profile
    {
        public CategoryDishesProfile()
        {
            CreateMap<Dish, CategoryDishDetails>()
            .ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForPath(dest => dest.DishName, opt => opt.MapFrom(src => src.Name))
            .ForPath(dest => dest.CousineName, opt => opt.MapFrom(src => src.Cousine.CousineName))
            .ForPath(dest => dest.CookingTime, opt => opt.MapFrom(src => src.CookingTime.Time));

        }
    }
}
