using AutoMapper;
using COE.Application.Abstractions.Context;
using COE.Application.Abstractions.Wrappers;
using COE.Application.DTOs;
using COE.Application.Wrappers;
using COE.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace COE.Application.Features.Queries.UserFeatures.UserGetAll
{
    public class UserGetAllQueryHandler : IRequestHandler<UserGetAllQueryRequest, IServiceResponse>
    {
        private readonly IApplicationDbContext _Context;
        private readonly IMapper _Mapper;

        public UserGetAllQueryHandler(IApplicationDbContext Context, IMapper Mapper)
        {
            _Context = Context;
            _Mapper = Mapper;
        }

        public async Task<IServiceResponse> Handle(UserGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            List<User> DbUsers = await _Context.Users.Where(u => !u.IsDeleted).ToListAsync();

            return new SuccessResponse<List<UserDTO>>() 
            {
                Value = _Mapper.Map<List<UserDTO>>(DbUsers),
                Message = "Users Fetched."
            };
        }
    }
}
