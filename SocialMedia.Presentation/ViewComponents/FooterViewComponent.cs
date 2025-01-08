using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace SocialMedia.Presentation.ViewComponents;

public class FooterViewComponent : ViewComponent
{
    public async Task <ViewViewComponentResult> InvokeAsync()
    {
        return View();
    }
}
