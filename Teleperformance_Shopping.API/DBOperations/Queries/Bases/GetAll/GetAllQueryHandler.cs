using AutoMapper;
using MediatR;
using Teleperformance_Shopping.API.DTOs;

namespace Teleperformance_Shopping.API.DBOperations.Queries.Bases.GetAll
{
    public abstract class GetAllQueryHandler<T> : IRequestHandler<GetAllQuery<T>, ResponseDto<IReadOnlyList<T>>>
        where T : class
    {
        protected readonly IMapper _mapper;
        protected IReadOnlyList<object> _baseEntities { get; set; }

        public GetAllQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public virtual async Task<ResponseDto<IReadOnlyList<T>>> Handle(GetAllQuery<T> request, CancellationToken cancellationToken)
        {
            return ResponseDto<IReadOnlyList<T>>.Success(_mapper.Map<IReadOnlyList<T>>(_baseEntities), 200);
        }
    }
}