using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Repositories.BaseRepository;
using Teleperformance_Shopping.API.Repositories.ProductRepository;
using Teleperformance_Shopping.API.Services.Commands;
using Teleperformance_Shopping.API.Services.Queries;

namespace Teleperformance_Shopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomControllerBase<TEntity, TViewModel, TEntityDto, TInsertModel, TUpdateModel> : ControllerBase
        where TEntity : class
        where TViewModel : class
        where TEntityDto : class
        where TInsertModel : class
        where TUpdateModel : class
    {
        //private readonly IMediator _mediator;
        protected readonly IMapper _mapper;
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IProductRepository _productRepository;

        public CustomControllerBase(IMapper mapper, IBaseRepository<TEntity> repository, IProductRepository productRepository)
        {
            //_mediator = mediator;
            _mapper = mapper;
            _repository = repository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getAllQuery = new GetAllGeneric<TEntity, TViewModel>(_repository, _mapper, _productRepository);
            var response = await getAllQuery.Handle();
            return CreateActionResult(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getByIdQuery = new GetByIdGeneric<TEntity, TViewModel>(_repository, _mapper, id);
            var response = await getByIdQuery.Handle();
            return CreateActionResult(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetBySearch(string keyword)
        {
            var getBySearchQuery = new GetBySearchGeneric<TEntity, TViewModel>(_repository, _mapper, keyword);
            var response = await getBySearchQuery.Handle();
            return CreateActionResult(response);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Add(TInsertModel request)
        {
            if (ModelState.IsValid)
            {
                var insertCommand = new InsertGeneric<TEntity, TInsertModel>(_repository, _mapper, request);
                var response = await insertCommand.Handle();
                return CreateActionResult(response);
            }
            return CreateActionResult(ResponseDto<NoContent>.Fail("Inputs are not valid", 404));
        }

        [HttpPut]
        public async Task<IActionResult> Update(TUpdateModel request)
        {
            if (ModelState.IsValid)
            {
                var updateCommand = new UpdateGeneric<TEntity, TUpdateModel>(_repository, _mapper, request);
                var response = await updateCommand.Handle();
                return CreateActionResult(response);
            }
            return CreateActionResult(ResponseDto<NoContent>.Fail("Inputs are not valid", 404));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int request)
        {
            var deleteCommand = new DeleteGeneric<TEntity>(_repository, request);
            var response = await deleteCommand.Handle();
            return CreateActionResult(response);
        }

        [NonAction] // Don't expose
        public IActionResult CreateActionResult<T>(ResponseDto<T> response)
        {
            // For swagger only. Not necessary for API
            if (response.StatusCode == 204)
                return new ObjectResult(null) { StatusCode = response.StatusCode };

            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}