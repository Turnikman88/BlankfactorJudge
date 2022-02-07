using JudgeSystem.Web.Filters;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace JudgeSystem.Web.Configuration
{
    public static class MvcConfiguration
    {
        private const int EntityNotFoundExceptionFilterOrder = 2;

        public static IServiceCollection ConfigureMvc(this IServiceCollection services)
        {
            services.AddControllersWithViews().AddViewLocalization();
            services.AddRazorPages()
                .AddRazorPagesOptions(options =>
                {
                    // options.AllowAreas = true; net6change/
                    options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                    options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                })
                .AddRazorRuntimeCompilation();

            return services;
        }
    }
}
