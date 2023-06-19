using COE.Application.Abstractions.Wrappers;
using MediatR;

namespace COE.Application.Features.Commands.UserFeatures.Update
{
    public class UserUpdateCommandRequest : IRequest<IServiceResponse>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string UpdatedBy { get; set; }
    }
}
