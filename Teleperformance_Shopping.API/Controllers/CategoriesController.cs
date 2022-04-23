using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Models;
using Teleperformance_Shopping.API.Repositories.BaseRepository;
using Teleperformance_Shopping.API.ViewModels;

namespace Teleperformance_Shopping.API.Controllers
{
    public class CategoriesController :
        CustomControllerBase<Category, CategoryViewModel,
        CategoryDto, CategoryInsertModel, CategoryUpdateModel>
    {
        public CategoriesController(IMapper mapper, IBaseRepository<Category> repository, IOptions<TokenData> options) : base(mapper, repository, options)
        {
        }
    }
}
