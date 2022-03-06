using AutoMapper;
using ServerPart.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Fridge, FridgeDto>();
            CreateMap<FridgeModel, FridgeModelDto>();
            CreateMap<FridgeProducts, FridgeProductsDto>();
            CreateMap<Products, ProductsDto>();


            CreateMap<CreationFridgeProductDto, FridgeProducts>();
        }
    }
}
