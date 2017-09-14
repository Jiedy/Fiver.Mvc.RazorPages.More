using Fiver.Mvc.RazorPages.More.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

            services.AddMvc();
            //services.AddMvc()
            //        .AddRazorPagesOptions(options =>
            //        {
            //            options.RootDirectory = "/Pages";
            //            options.Conventions.AddPageRoute("/Routing", "NewRouting");
            //        });
        }

        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
