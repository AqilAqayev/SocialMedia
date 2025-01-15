using SocialMedia.DataAccess.ServiceRegistrations;
using SocalMedia.Business.ServiceRegistrations;
using Microsoft.AspNetCore.Identity;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Context;
using SocalMedia.Business.Hubs;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddBllServices();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme =GoogleDefaults.AuthenticationScheme;
}).AddCookie()
.AddGoogle(GoogleDefaults.AuthenticationScheme,options =>
{
    options.ClientId = builder.Configuration.GetSection("GoogleKeys:ClientId").Value ?? "";
    options.ClientSecret = builder.Configuration.GetSection("GoogleKeys:ClientSecret").Value ?? "";
});
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;    
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
    options.Password.RequireNonAlphanumeric = true;
    
    //options.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapHub<ChatHub>("/chathub");
app.MapHub<CommentHub>("/postHub");


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
