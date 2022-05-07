using AutoMapper;
using ClientPart.Models;
using ClientPart.ViewModels;

namespace ClientPart.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // models in view models
            CreateMap<FridgeModel, FridgeModelViewModel>();
            CreateMap<Fridge, FridgesViewModel>();
            CreateMap<Fridge, AddOrUpdateFridgeViewModel>().ReverseMap();
            CreateMap<FridgeProducts, FridgeProductsViewModel>();
            CreateMap<Products, AddProductInFridgeViewModel>();
            CreateMap<Products, ProductsViewModel>();
            CreateMap<Products, UpdatedProductViewModel>().ReverseMap();


            // view models back to models
            CreateMap<AddOrUpdateFridgeViewModel, Fridge>().ReverseMap();
            CreateMap<AddOrUpdateFridgeViewModel, Fridge>();
            CreateMap<FridgesViewModel, AddOrUpdateFridgeViewModel>();
            CreateMap<ProductsViewModel, UpdatedProductViewModel>();
            CreateMap<RegistrationUserViewModel, User>();
            CreateMap<AuthenticationUserViewModel, AuthenticationUser>();     
        }
    }
}
