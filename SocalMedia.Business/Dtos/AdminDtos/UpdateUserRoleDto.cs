using Microsoft.AspNetCore.Mvc.Rendering;

namespace SocalMedia.Business.Dtos.AdminDtos;

public class UpdateUserRoleDto
{
    public string UserId { get; set; } = null!;
    public bool CurrentRole { get; set; }
    public bool NewRole { get; set; }
    public bool IsDisabled { get; set; }
    public List<SelectListItem> Roles { get; set; } = [];
}
