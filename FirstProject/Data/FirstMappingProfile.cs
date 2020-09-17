using AutoMapper;
using FirstProject.Data.Entities;
using FirstProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProject.Data
{
    public class FirstMappingProfile : Profile
    {
        public FirstMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id))
                .ReverseMap();
        }
    }
}
