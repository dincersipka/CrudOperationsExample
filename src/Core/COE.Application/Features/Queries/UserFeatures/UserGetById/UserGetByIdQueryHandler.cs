using AutoMapper;
using COE.Application.Abstractions.Context;
using COE.Application.Abstractions.Wrappers;
using COE.Application.DTOs;
using COE.Application.Exceptions;
using COE.Application.Features.Queries.UserFeatures.UserGetAll;
using COE.Application.Wrappers;
using COE.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace COE.Application.Features.Queries.UserFeatures.UserGetById
{
    public class UserGetByIdQueryHandler : IRequestHandler<UserGetByIdQueryRequest, IServiceResponse>
    {
        private readonly IApplicationDbContext _Context;
        private readonly IMapper _Mapper;

        public UserGetByIdQueryHandler(IApplicationDbContext Context, IMapper Mapper)
        {
            _Context = Context;
            _Mapper = Mapper;
        }

        public async Task<IServiceResponse> Handle(UserGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            User DbUser = await _Context.Users.Where(u => !u.IsDeleted).FirstOrDefaultAsync();

            if (DbUser is null)
                throw new UserNotFoundException();

            return new SuccessResponse<UserDTO>()
            {
                Value = _Mapper.Map<UserDTO>(DbUser),
                Message = "User Fetched."
            };
        }
    }
}
