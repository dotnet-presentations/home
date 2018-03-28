using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AuthorizationPolicies
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IRoomAccess, RoomAccessRepository>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, configure =>
                {
                    configure.LoginPath = new PathString("/Account/Login/");
                    configure.AccessDeniedPath = new PathString("/Account/Forbidden/");
                });

            services.AddAuthorization(configure =>
            {
                configure.AddPolicy(
                    AuthorizationPolicies.MicrosoftBadge,
                    policy => 
                    policy.Requirements.Add(new MicrosoftOnlyRequirement()));

            });

            services.AddSingleton<IAuthorizationHandler, MicrosoftOnlyAuthorizationHandler>();
            services.AddTransient<IAuthorizationHandler, RoomEntryAuthorizationHandler>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
