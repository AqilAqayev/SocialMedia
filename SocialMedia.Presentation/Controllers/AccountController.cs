using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SocalMedia.Business.Dtos;
using SocalMedia.Business.Services.Abstractions;
using SocialMedia.Core.Entities;

namespace SocialMedia.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailService _emailService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailService, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;

            _signInManager = signInManager;
            _emailService = emailService;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = new AppUser
            {
                NickName = registerDto.NickName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
                CreatedTime= DateTime.UtcNow,
                UpdateTime= DateTime.UtcNow,
                Gender = registerDto.Gender,
                EmailConfirmed = false
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var confirmationLink = Url.Action("ConfirmEmail", "Account",
                new { userId = user.Id, token = token }, Request.Scheme);

            _emailService.SendEmail(user.Email, "Email Confirmation",
                $"Please confirm your email by clicking <a href='{confirmationLink}'>here</a>.");

            return RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return BadRequest("Invalid email confirmation request.");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return View("ConfirmEmail");
            }

            return BadRequest("Email confirmation failed.");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Username or password is incorrect.");
                return View();
            }

            if (!user.EmailConfirmed)
            {
                ModelState.AddModelError("", "Please confirm your email to log in.");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password is incorrect.");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
