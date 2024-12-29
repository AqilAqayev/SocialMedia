using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.ProfileDtos;

public class ProfileDto : IDto
{
    public string? Name { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public int FollowCount { get; set; }
    public int FollowingCount { get; set; }
    public List<PostDto> Posts { get; set; } = [];
    public string? ProfilePhoto { get; set; }
    public int PostCount { get; set; }
    public string? BioNews { get; set; }
    public List<string> ImageUrls { get; set; } = new List<string>(); 

}

public class ProfileOther : IDto
{
    public string? userId { get; set;}
    public string? Name { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public int FollowCount { get; set; }
    public int FollowingCount { get; set; }
    public List<PostDto> Posts { get; set; } = [];
    public string? ProfilePhoto { get; set; }
    public int PostCount { get; set; }
}


