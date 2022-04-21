using MediatR;
using Teleperformance_Shopping.API.DTOs;

namespace Teleperformance_Shopping.API.DBOperations.Queries.Bases.GetById
{
    public class GetByIdQuery<T> : IRequest<ResponseDto<T>> where T : class
    {
        public int Id { get; set; }
    }
}
