using Microsoft.AspNetCore.Mvc;
using SocalMedia.Business.Dtos.Account;
using SocalMedia.Business.Dtos.ProfileDtos;
using SocalMedia.Business.UiServices.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Presentation.Controllers;

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

    public IActionResult ForgotPassword() => View();

    [HttpPost]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
    {
        if (!ModelState.IsValid)
            return View();

        var user = await _accountService.FindUserByEmailAsync(forgotPasswordDto.Email);

        var token = await _accountService.GeneratePasswordResetTokenAsync(user);

        var resetLink = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme);

        await _accountService.SendEmailAsync(user.Email, "Password Reset",
            $"Click <a href='{resetLink}'>here</a> to reset your password.");


        return RedirectToAction("Login");
    }

    public IActionResult ResetPassword(string token, string email)
    {
        if (token == null || email == null)
            return BadRequest("Invalid password reset request.");

        var model = new ResetPasswordDto { Token = token, Email = email };
        return View(model);
    }


    [HttpPost]
    public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
    {
        if (!ModelState.IsValid)
            return View(resetPasswordDto);

        var user = await _accountService.FindUser();

        var result = await _accountService.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.NewPassword);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(resetPasswordDto);
        }

        return RedirectToAction("Login");
    }


    [HttpGet]
    public async Task<IActionResult> EditProfile()
    {
        var user = await _accountService.FindUser();

        var model = new EditProfileDto
        {
            UserName = user.UserName,
            Bio = user.Biography,
            PhoneNumber = user.PhoneNumber,
            IsPrivate = user.IsPrivate
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EditProfile(EditProfileDto editProfileDto)
    {
        if (!ModelState.IsValid)
        {
            return View(editProfileDto);
        }

        var user = await _accountService.FindUser();

        var success = await _accountService.EditProfileAsync(user, editProfileDto);

        return RedirectToAction("Index", "Profile");
    }


    [HttpGet]
    public async Task<IActionResult> ChangePassword()
    {
        var user = await _accountService.FindUser();
        if (user == null)
        {
            return RedirectToAction("Login");
        }

        var hasPassword = await _accountService.UserHasPasswordAsync(user);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordDto model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _accountService.FindUser();
        var result = await _accountService.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

        //if (!result.Succeeded)
        //{
        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError("", error.Description);
        //    }
        //    return View(model);
        //}

        return RedirectToAction("Index", "Home");

    }





}



