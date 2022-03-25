﻿using AutoMapper;
using ClientPart.Models;
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
            // models in view models
            CreateMap<FridgeModel, FridgeModelViewModel>();
            CreateMap<Fridge, FridgesViewModel>();
            CreateMap<Fridge, UpdatedFridgeViewModel>();
            CreateMap<FridgeProducts, FridgeProductsViewModel>();
            CreateMap<Products, AddProductInFridgeViewModel>();
            CreateMap<Products, ProductsViewModel>();
            CreateMap<Products, UpdatedProductViewModel>();


            // view models back to models
            CreateMap<UpdatedFridgeViewModel, Fridge>();
            CreateMap<AddFridgeViewModel, Fridge>();
            CreateMap<UpdatedProductViewModel, Products>();
            CreateMap<FridgesViewModel, UpdatedFridgeViewModel>();
            CreateMap<ProductsViewModel, UpdatedProductViewModel>();
            CreateMap<UpdatedFridgeViewModel, UpdatedShortFridgeViewModel>();

                 
        }
    }
}
