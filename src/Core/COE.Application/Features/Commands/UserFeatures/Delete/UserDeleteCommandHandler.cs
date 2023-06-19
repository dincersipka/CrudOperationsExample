using AutoMapper;
using COE.Application.Abstractions.Context;
using COE.Application.Abstractions.Wrappers;
using COE.Application.Exceptions;
using COE.Application.Wrappers;
using COE.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace COE.Application.Features.Commands.UserFeatures.Delete
{
    public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommandRequest, IServiceResponse>
    {
        private readonly IApplicationDbContext _Context;
        private readonly IMapper _Mapper;

        public UserDeleteCommandHandler(IApplicationDbContext Context, IMapper Mapper)
        {
            _Context = Context;
            _Mapper = Mapper;
        }

        public async Task<IServiceResponse> Handle(UserDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            User DbUser = await _Context.Users.Where(u => !u.IsDeleted).FirstOrDefaultAsync();

            if (DbUser is null)
                throw new UserNotFoundException();

            _Mapper.Map(request, DbUser);

            DbUser.DeleteDate = DateTime.UtcNow;
            DbUser.IsDeleted = true;

            await _Context.SaveChangesAsync(cancellationToken);

            return new SuccessResponse<Guid>()
            {
                Value = DbUser.Id,
                Message = "User Deleted."
            };
        }
    }
}
