using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using SocalMedia.Business.Dtos.Account;
using SocalMedia.Business.UiServices.Abstractions;
using SocialMedia.Core.Entities;
using System.Security.Claims;

public class AccountService : IAccountService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IEmailService _emailService;
    private readonly ICloudinaryManager _cloudinaryManager;

    public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailService, ICloudinaryManager cloudinaryManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailService = emailService;
        _cloudinaryManager = cloudinaryManager;
    }

    public async Task<IdentityResult> RegisterUserAsync(RegisterDto registerDto)
    {
        string profilePhotoUrl = registerDto.ProfilePhoto == null
            ? "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png"
            : await _cloudinaryManager.FileCreateAsync(registerDto.ProfilePhoto);

        var user = new AppUser
        {
            UserName = registerDto.UserName,
            NickName = registerDto.NickName,
            Email = registerDto.Email,
            PhoneNumber = registerDto.PhoneNumber,
            CreatedTime = DateTime.UtcNow,
            UpdateTime = DateTime.UtcNow,
            Gender = registerDto.Gender,
            EmailConfirmed = false,
            ProfilePhotoUrl = profilePhotoUrl
        };

        return await _userManager.CreateAsync(user, registerDto.Password);
    }

    public async Task<string> GenerateEmailConfirmationTokenAsync(AppUser user) =>
        await _userManager.GenerateEmailConfirmationTokenAsync(user);

    public async Task<AppUser> FindUserByEmailAsync(string email) =>
        await _userManager.FindByEmailAsync(email);

    public async Task<AppUser> FindUserByIdAsync(string userId) =>
        await _userManager.FindByIdAsync(userId);

    public async Task<IdentityResult> ConfirmEmailAsync(AppUser user, string token) =>
        await _userManager.ConfirmEmailAsync(user, token);

    public async Task<SignInResult> LoginUserAsync(LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (user == null || !user.EmailConfirmed) return SignInResult.Failed;

        return await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, true);
    }

    public async Task LogoutUserAsync() =>
        await _signInManager.SignOutAsync();

    public AuthenticationProperties GetGoogleLoginProperties(string redirectUrl)
    {
        return _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
    }

    public async Task<ExternalLoginInfo> GetExternalLoginInfoAsync() =>
        await _signInManager.GetExternalLoginInfoAsync();

    public async Task<AppUser> HandleGoogleLoginAsync(ExternalLoginInfo info)
    {
        var email = info.Principal.FindFirstValue(ClaimTypes.Email);
        var userName = info.Principal.FindFirstValue(ClaimTypes.Name);

        if (!string.IsNullOrEmpty(userName))
        {
            userName = userName.Replace(" ", "_");
        }

        var existingUser = await _userManager.FindByEmailAsync(email);
        if (existingUser != null)
        {
            await _signInManager.SignInAsync(existingUser, isPersistent: false);
            return existingUser;
        }

        var newUser = new AppUser
        {
            UserName = userName ?? $"google_{Guid.NewGuid()}",
            NickName = userName ?? $"google_{Guid.NewGuid()}",
            Email = email,
            CreatedTime = DateTime.UtcNow,
            UpdateTime = DateTime.UtcNow,
            EmailConfirmed = true,
            ProfilePhotoUrl = info.Principal.FindFirstValue("picture") ?? "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png"
        };

        var createResult = await _userManager.CreateAsync(newUser);
        if (!createResult.Succeeded) return null;

        await _userManager.AddLoginAsync(newUser, info);

        await _signInManager.SignInAsync(newUser, isPersistent: false);

        return newUser;
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
         _emailService.SendEmail(to, subject, body);
    }
}
