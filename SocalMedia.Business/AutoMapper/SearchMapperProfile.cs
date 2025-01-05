using AutoMapper;
using SocalMedia.Business.Dtos.SearchDtos;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.AutoMapper;

public class SearchMapperProfile : Profile
{
    public SearchMapperProfile()
    {
        CreateMap<AppUser, SearchDto>()
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));

        // List<AppUser> -> SearchUsersDto
        CreateMap<List<AppUser>, SearchUsersDto>()
            .ForMember(dest => dest.SearchDtos, opt => opt.MapFrom(src => src));
    }
}
