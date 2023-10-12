using Microsoft.AspNetCore.Authentication.Cookies;
using ScannerWebApp.IServices;
using ScannerWebApp.Services;

namespace ScannerWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddHttpClient("YourHttpClientName")
            //    .ConfigurePrimaryHttpMessageHandler(() =>
            //    {
            //        var handler = new HttpClientHandler();
            //        handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            //        return handler;
            //    });
            builder.Services.AddHttpClient();
            builder.Services.AddTransient<IScanner, Scanner>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
          .AddCookie(options =>
          {
              options.LoginPath = "/Account/Login"; // Set the login path
              options.LogoutPath = "/Account/Logout"; // Set the logout path
              options.AccessDeniedPath = "/Account/Login"; // Set the access denied path
          });
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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}