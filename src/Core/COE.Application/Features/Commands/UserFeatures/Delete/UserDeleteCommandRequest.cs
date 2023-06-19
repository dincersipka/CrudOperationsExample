using COE.Application.Abstractions.Wrappers;
using MediatR;

namespace COE.Application.Features.Commands.UserFeatures.Delete
{
    public class UserDeleteCommandRequest : IRequest<IServiceResponse>
    {
        public Guid Id { get; set; }
        public string DeletedBy { get; set; }
    }
}
