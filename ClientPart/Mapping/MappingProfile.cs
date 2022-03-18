using AutoMapper;
using ClientPart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FridgesViewModel, UpdatedFridgeViewModel>();
            CreateMap<ProductsViewModel, AddProductInFridgeViewModel>();
            CreateMap<UpdatedFridgeViewModel, UpdatedShortFridgeViewModel>();
            CreateMap<AddFridgeViewModel, AddShortFridgeViewModel>();
        }
    }
}
