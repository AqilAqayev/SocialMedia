using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using SocalMedia.Business.Dtos.Account;
using SocalMedia.Business.Dtos.ProfileDtos;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.UiServices.Abstractions;
public interface IAccountService
{
    Task<string> GetRedirectUrlAfterLogin(AppUser user);
    Task<AppUser> FindUser();
    Task<bool> UserHasPasswordAsync(AppUser user);
    Task<IdentityResult> RegisterUserAsync(RegisterDto registerDto);
    Task<IdentityResult> ResetPasswordAsync(AppUser user, string token, string newPassword);
    Task<string> GeneratePasswordResetTokenAsync(AppUser user);
    Task<string> GenerateEmailConfirmationTokenAsync(AppUser user);
    Task<AppUser> FindUserByEmailAsync(string email);
    Task<AppUser> FindUserByIdAsync(string Id);
    Task<IdentityResult> ConfirmEmailAsync(AppUser user, string token);
    Task<SignInResult> LoginUserAsync(LoginDto loginDto);
    Task LogoutUserAsync();
    AuthenticationProperties GetGoogleLoginProperties(string redirectUrl);
    Task<ExternalLoginInfo> GetExternalLoginInfoAsync();
    Task<AppUser> HandleGoogleLoginAsync(ExternalLoginInfo info);
    Task SendEmailAsync(string to, string subject, string body);
    Task<bool> EditProfileAsync(AppUser user, EditProfileDto editProfileDto);
    Task<IdentityResult> ChangePasswordAsync(AppUser user, string oldPassword, string newPassword);

}
