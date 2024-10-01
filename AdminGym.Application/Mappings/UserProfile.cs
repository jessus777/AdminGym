using AdminGym.Application.Features.UserManagement.Dtos;
using AdminGym.Domain.Entities;
using AutoMapper;

namespace AdminGym.Application.Mappings;
public class UserProfile
    : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserCommandDto, User>()
            .ForMember(dest => dest.UserName,
            opt => opt.MapFrom(
                src => $"{src.FirstName.Trim().ToLower()}" +
                        $"{src.SecondName.Trim().ToLower()}" +
                        $"{src.PaternalSurname.Trim().ToLower()}" +
                        $"{src.MaternalSurname.Trim().ToLower()}"
            ));
        CreateMap<User, CreateUserCommandDto>();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, UserGetByIdResponseDto>();
    }
}
