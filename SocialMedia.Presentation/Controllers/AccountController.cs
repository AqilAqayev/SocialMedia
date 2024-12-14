using Microsoft.AspNetCore.Mvc;

namespace SocialMedia.Presentation.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
