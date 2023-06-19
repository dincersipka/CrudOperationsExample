using COE.Application.Abstractions.Wrappers;
using MediatR;

namespace COE.Application.Features.Queries.UserFeatures.UserGetById
{
    public class UserGetByIdQueryRequest : IRequest<IServiceResponse>
    {
        public Guid Id { get; set; }
    }
}
