using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;
using PbxHub.Admin.App.Services;
using PbxHub.Admin.App.Services.Middlewares;
using MudBlazor;

namespace PbxHub.Admin.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;
                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = false;
                config.SnackbarConfiguration.ShowCloseIcon = false;
                config.SnackbarConfiguration.VisibleStateDuration = 10000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });
            
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationProvider>();
            services.AddAuthorizationCore();
            services.AddScoped<ILocalStorageService, LocalStorageService>();

            services.AddHttpClient<IClientService, ClientService>(client =>
            {
                client.BaseAddress = new Uri(Configuration["apiUrl"]);
            });

            services.AddHttpClient<IAccountService, AccountService>(client =>
            {
                client.BaseAddress = new Uri(Configuration["apiUrl"]);
            });

            services.AddHttpClient<IUserService, UserService>(client =>
            {
                client.BaseAddress = new Uri(Configuration["apiUrl"]);
            });

            services.AddHttpClient<IQueueService, QueueService>(client =>
            {
                client.BaseAddress = new Uri(Configuration["apiUrl"]);
            });

            services.AddHttpClient<IAttendantService, AttendantService>(client =>
            {
                client.BaseAddress = new Uri(Configuration["apiUrl"]);
            });

            services.AddHttpClient<IQueueMemberService, QueueMemberService>(client =>
            {
                client.BaseAddress = new Uri(Configuration["apiUrl"]);
            });

            services.AddHttpClient<INumberRouteService, NumberRouteService>(client =>
            {
                client.BaseAddress = new Uri(Configuration["apiUrl"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
