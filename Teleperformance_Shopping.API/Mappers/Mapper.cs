using AutoMapper;
using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Models;
using Teleperformance_Shopping.API.Services.Commands.InsertModels;
using Teleperformance_Shopping.API.Services.Commands.UpdateModels;
using Teleperformance_Shopping.API.ViewModels;

namespace Teleperformance_Shopping.API.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Category, int>().ConvertUsing(x => x.Id);
            CreateMap<CategoryDto, int>().ConvertUsing(x => x.Id);
            CreateMap<CategoryViewModel, int>().ConvertUsing(x => x.Id);

            CreateMap<int, Category>().ConvertUsing(x => new Category() { Id = x });
            CreateMap<int, CategoryDto>().ConvertUsing(x => new CategoryDto() { Id = x });
            CreateMap<int, CategoryViewModel>().ConvertUsing(x => new CategoryViewModel() { Id = x });

            CreateMap<Product, ProductViewModel>()
                .ReverseMap();
            CreateMap<ShoppingList, ShoppingListViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ShoppingList, ShoppingListDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<ProductInsertModel, Product>().ForMember(dest => dest.Category, opts => opts.MapFrom(o => o.CategoryId));
            CreateMap<ShoppingList, ShoppingListInsertModel>().ReverseMap();
            CreateMap<User, UserInsertModel>().ReverseMap();
            CreateMap<Category, CategoryInsertModel>().ReverseMap();

            CreateMap<Product, ProductUpdateModel>().ForMember(dest => dest.CategoryId, opts => opts.MapFrom(o => o.Category)).ReverseMap();
            CreateMap<ShoppingList, ShoppingListUpdateModel>().ReverseMap();
            CreateMap<User, UserUpdateModel>().ReverseMap();
            CreateMap<Category, CategoryUpdateModel>().ReverseMap();
        }
    }
}