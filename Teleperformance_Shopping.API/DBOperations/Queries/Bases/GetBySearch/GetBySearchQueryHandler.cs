using AutoMapper;
using MediatR;
using Teleperformance_Shopping.API.DTOs;

namespace Teleperformance_Shopping.API.DBOperations.Queries.Bases.GetBySearch
{
    public class GetBySearchQueryHandler<T> : IRequestHandler<GetBySearchQuery<T>, ResponseDto<IReadOnlyList<T>>>
    where T : class
    {
        protected readonly IMapper _mapper;
        protected IReadOnlyList<object> _baseEntities { get; set; }
        public GetBySearchQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public virtual async Task<ResponseDto<IReadOnlyList<T>>> Handle(GetBySearchQuery<T> request, CancellationToken cancellationToken)
        {
            return ResponseDto<IReadOnlyList<T>>.Success(_mapper.Map<IReadOnlyList<T>>(_baseEntities), 200);
        }
    }
}
