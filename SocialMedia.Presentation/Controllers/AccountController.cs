using Microsoft.AspNetCore.Mvc;
using SocalMedia.Business.Dtos.Account;
using SocalMedia.Business.UiServices.Abstractions;

namespace SocialMedia.Presentation.Controllers

{

    namespace SocialMedia.Presentation.Controllers
    {
        public class AccountController : Controller
        {
            private readonly IAccountService _accountService;

            public AccountController(IAccountService accountService)
            {
                _accountService = accountService;
            }

            public IActionResult Register() => View();

            [HttpPost]
            public async Task<IActionResult> Register(RegisterDto registerDto)
            {
                if (!ModelState.IsValid)
                    return View();

                var result = await _accountService.RegisterUserAsync(registerDto);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View();
                }

                var user = await _accountService.FindUserByEmailAsync(registerDto.Email);
                var token = await _accountService.GenerateEmailConfirmationTokenAsync(user);

                var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token }, Request.Scheme);
                await _accountService.SendEmailAsync(user.Email, "Email Confirmation",
                    $"Please confirm your email by clicking <a href='{confirmationLink}'>here</a>.");

                return RedirectToAction("Login");
            }

            public async Task<IActionResult> ConfirmEmail(string userId, string token)
            {
                if (userId == null || token == null)
                    return BadRequest("Invalid email confirmation request.");

                var user = await _accountService.FindUserByIdAsync(userId);
                if (user == null)
                    return NotFound("User not found.");

                var result = await _accountService.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                    return View("ConfirmEmail");

                return BadRequest("Email confirmation failed.");
            }

            public IActionResult Login() => View();

            [HttpPost]
            public async Task<IActionResult> Login(LoginDto loginDto)
            {
                if (!ModelState.IsValid)
                    return View();

                var result = await _accountService.LoginUserAsync(loginDto);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Username or password is incorrect.");
                    return View();
                }

                return RedirectToAction("Index", "Home");
            }

            public async Task<IActionResult> Logout()
            {
                await _accountService.LogoutUserAsync();
                return RedirectToAction("Login", "Account");
            }

            [HttpGet]
            public IActionResult LoginWithGoogle()
            {
                var redirectUrl = Url.Action("GoogleResponse", "Account");
                var properties = _accountService.GetGoogleLoginProperties(redirectUrl);
                return Challenge(properties, "Google");
            }

            public async Task<IActionResult> GoogleResponse()
            {
                var info = await _accountService.GetExternalLoginInfoAsync();
                if (info == null)
                    return RedirectToAction("Login", new { error = "Google login failed." });

                var user = await _accountService.HandleGoogleLoginAsync(info);
                if (user == null)
                    return RedirectToAction("Login", new { error = "Google registration failed." });

                return RedirectToAction("Index", "Home");
            }
        }
    }

}
