using Fiver.Mvc.RazorPages.More.Filters;
using Fiver.Mvc.RazorPages.More.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Fiver.Mvc.RazorPages.More
{
    public class Startup
    {
        public void ConfigureServices(
            IServiceCollection services)
        {
            services.AddSingleton<IFileProvider>(
                new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files")));

            services.AddScoped<ILookupService, LookupService>();

            services.AddScoped<IGreetingService, GreetingService>();

            services.AddScoped<GreetingServiceFilter>();

            services.AddAuthentication("FiverSecurityScheme")
                    .AddCookie("FiverSecurityScheme", options =>
                    {
                        options.AccessDeniedPath = new PathString("/Security/Access");
                        options.LoginPath = new PathString("/Security/Login");
                    });

            //services.AddMvc();
            //services.AddMvc()
            //        .AddRazorPagesOptions(options =>
            //        {
            //            options.RootDirectory = "/Pages";
            //            options.Conventions.AddPageRoute("/Routing", "NewRouting");
            //        });

            services.AddMvc()
                    .AddRazorPagesOptions(options =>
                    {
                        options.Conventions.AuthorizeFolder("/ProtectedPages");
                    });
        }

        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
