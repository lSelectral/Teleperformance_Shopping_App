using MediatR;
using Teleperformance_Shopping.API.DTOs;

namespace Teleperformance_Shopping.API.DBOperations.Queries.Bases.GetAll
{
    public class GetAllQuery<T> : IRequest<ResponseDto<IReadOnlyList<T>>> where T : class
    {
    }
}
