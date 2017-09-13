using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Fiver.Mvc.RazorPages.More
{
    public class Startup
    {
        public void ConfigureServices(
            IServiceCollection services)
        {
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
            app.UseMvcWithDefaultRoute();
        }
    }
}
