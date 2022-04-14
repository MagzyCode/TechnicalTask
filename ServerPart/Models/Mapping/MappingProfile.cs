using AutoMapper;
using ServerPart.Models.DTOs;

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

            CreateMap<UpdateProductsDto, Products>();
            CreateMap<CreationFridgeProductDto, FridgeProducts>();
            CreateMap<UpdateFridgeProductDto, FridgeProducts>();
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<UpdateFridgeDto, Fridge>();
            CreateMap<CreationFridgeDto, Fridge>();
        }
    }
}
