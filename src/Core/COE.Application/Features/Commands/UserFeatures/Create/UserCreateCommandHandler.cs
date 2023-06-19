using AutoMapper;
using COE.Application.Abstractions.Context;
using COE.Application.Abstractions.Wrappers;
using COE.Application.DTOs;
using COE.Application.Wrappers;
using COE.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace COE.Application.Features.Commands.UserFeatures.Create
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommandRequest, IServiceResponse>
    {
        private readonly IApplicationDbContext _Context;
        private readonly IMapper _Mapper;

        public UserCreateCommandHandler(IApplicationDbContext Context, IMapper Mapper)
        {
            _Context = Context;
            _Mapper = Mapper;
        }

        public async Task<IServiceResponse> Handle(UserCreateCommandRequest request, CancellationToken cancellationToken)
        {
            User NewUser = _Mapper.Map<User>(request);

            EntityEntry<User> DbUserEntry = await _Context.Users.AddAsync(NewUser);
            await _Context.SaveChangesAsync(cancellationToken);

            return new SuccessResponse<UserDTO>()
            {
                Value = _Mapper.Map<UserDTO>(DbUserEntry.Entity),
                Message = "User Created."
            };
        }
    }
}
