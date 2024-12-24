using System.Security.Claims;

namespace SocialMedia.Presentation.Extensions;

public static class ExtensionMethods
{
    public static string GetUserId(this ClaimsPrincipal user)
    {
        return user.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
    }

    public static string GetReturnUrl(this HttpRequest request)
    {
        string? retunUrl = request.Headers["Referer"];

        if (retunUrl is null)
            retunUrl = "/";

        return retunUrl;
    }
}
