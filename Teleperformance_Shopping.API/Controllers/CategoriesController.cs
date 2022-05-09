using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Models;
using Teleperformance_Shopping.API.ViewModels;
using Teleperformance_Shopping.API.Repositories.BaseRepository;

namespace Teleperformance_Shopping.API.Controllers
{
    public class CategoriesController :
        CustomControllerBase<Category, CategoryViewModel,
        CategoryDto, CategoryInsertModel, CategoryUpdateModel>
    {
        public CategoriesController(IMapper mapper, IBaseRepository<Category> repository, IOptions<TokenData> options) : base(mapper, repository, options)
        {
        }

        [Authorize(Roles = "admin")]
        public override Task<IActionResult> Add(CategoryInsertModel request)
        {
            return base.Add(request);
        }

        [Authorize(Roles = "admin")]
        public override Task<IActionResult> Update(CategoryUpdateModel request)
        {
            return base.Update(request);
        }

        [Authorize(Roles = "admin")]
        public override Task<IActionResult> Delete([FromQuery] int id)
        {
            return base.Delete(id);
        }
    }
}
