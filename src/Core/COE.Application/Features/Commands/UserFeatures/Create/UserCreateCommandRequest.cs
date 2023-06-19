using COE.Application.Abstractions.Wrappers;
using MediatR;

namespace COE.Application.Features.Commands.UserFeatures.Create
{
    public class UserCreateCommandRequest : IRequest<IServiceResponse>
    {
        public string Username { get; set; }
        public string CreatedBy { get; set; }
    }
}
