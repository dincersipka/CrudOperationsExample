using AutoMapper;
using COE.Application.DTOs;
using COE.Application.Features.Commands.UserFeatures.Create;
using COE.Application.Features.Commands.UserFeatures.Delete;
using COE.Application.Features.Commands.UserFeatures.Update;
using COE.Domain.Entities;

namespace COE.Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<User, UserCreateCommandRequest>().ReverseMap();
            CreateMap<User, UserUpdateCommandRequest>().ReverseMap();
            CreateMap<User, UserDeleteCommandRequest>().ReverseMap();
        }
    }
}
