using SocialMedia.DataAccess.DataInitalizers;
using System.Security.Claims;

namespace SocialMedia.Presentation.Extensions;

public static class ExtensionMethods
{
    public static async Task InitDatabaseAsync(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var initializer = scope.ServiceProvider.GetRequiredService<DbContextInitalizer>();
            await initializer.InitDatabaseAsync();
        }
    }
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
