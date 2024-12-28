using SocalMedia.Business.Dtos.ProfileDtos;

namespace SocalMedia.Business.UiServices.Abstractions;

public interface IProfileService
{
    Task<ProfileDto> GetProfile();
    Task<ProfileOther> GetProfileOther(string userId);
}
