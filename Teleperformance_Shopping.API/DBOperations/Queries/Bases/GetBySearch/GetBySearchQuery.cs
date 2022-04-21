using MediatR;
using Teleperformance_Shopping.API.DTOs;

namespace Teleperformance_Shopping.API.DBOperations.Queries.Bases.GetBySearch
{
    public class GetBySearchQuery<T> : IRequest<ResponseDto<IReadOnlyList<T>>> where T : class
    {
        public string Keyword { get; set; }
    }
}
