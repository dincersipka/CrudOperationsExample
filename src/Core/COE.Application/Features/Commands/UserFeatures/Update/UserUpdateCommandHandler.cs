using AutoMapper;
using COE.Application.Abstractions.Context;
using COE.Application.Abstractions.Wrappers;
using COE.Application.DTOs;
using COE.Application.Exceptions;
using COE.Application.Features.Commands.UserFeatures.Create;
using COE.Application.Wrappers;
using COE.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace COE.Application.Features.Commands.UserFeatures.Update
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommandRequest, IServiceResponse>
    {
        private readonly IApplicationDbContext _Context;
        private readonly IMapper _Mapper;

        public UserUpdateCommandHandler(IApplicationDbContext Context, IMapper Mapper)
        {
            _Context = Context;
            _Mapper = Mapper;
        }

        public async Task<IServiceResponse> Handle(UserUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            User DbUser = await _Context.Users.Where(u => !u.IsDeleted).FirstOrDefaultAsync();

            if (DbUser is null)
                throw new UserNotFoundException();

            _Mapper.Map(request, DbUser);

            DbUser.UpdateDate = DateTime.UtcNow;

            await _Context.SaveChangesAsync(cancellationToken);

            return new SuccessResponse<UserDTO>()
            {
                Value = _Mapper.Map<UserDTO>(DbUser),
                Message = "User Updated."
            };
        }
    }
}
