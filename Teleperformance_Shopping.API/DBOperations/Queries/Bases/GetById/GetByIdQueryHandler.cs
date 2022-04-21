using AutoMapper;
using MediatR;
using Teleperformance_Shopping.API.DTOs;

namespace Teleperformance_Shopping.API.DBOperations.Queries.Bases.GetById
{
    public class GetByIdQueryHandler<T> : IRequestHandler<GetByIdQuery<T>, ResponseDto<T>>
    where T : class
    {
        protected readonly IMapper _mapper;
        protected object _baseEntity { get; set; }

        public GetByIdQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public virtual async Task<ResponseDto<T>> Handle(GetByIdQuery<T> request, CancellationToken cancellationToken)
        {
            return ResponseDto<T>.Success(_mapper.Map<T>(_baseEntity), 200);
        }
    }
}
