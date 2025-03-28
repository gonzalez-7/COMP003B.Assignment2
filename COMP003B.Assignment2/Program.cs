/*
Name: Antonio Gonzalez
Course: COMP-003B: ASP.NET Core
Faculty: Jonathan Cruz
Purpose: This application demonstrates MVC concepts, including middleware, controllers, views, and layout design.
*/

using COMP003B.Assignment2.Middleware;  

namespace COMP003B.Assignment2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Enable HTTPS redirection and static file handling
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Enable built-in Welcome Page at /welcome
            app.UseWelcomePage("/welcome");

            // Register custom middleware
            app.UseMiddleware<COMP003B.Assignment2.Middleware.RequestTrackerMiddleware>();

            app.UseRouting();
            app.UseAuthorization();

            // Default MVC routing
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
