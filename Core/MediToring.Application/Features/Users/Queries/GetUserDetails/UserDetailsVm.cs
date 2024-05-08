using AutoMapper;
using MediToring.Application.Common.Mappings;
using MediToring.Domain.Users;

namespace MediToring.Application.Features.Users.Queries.GetUserDetails;

public class UserDetailsVm : IMapWith<User>
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserDetailsVm>()
            .ForMember(userVm => userVm.Email,
                opt => opt.MapFrom(user => user.Email))
            .ForMember(userVm => userVm.Name,
                opt => opt.MapFrom(user => user.Name));
    }
}