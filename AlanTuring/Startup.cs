using AlanTuring.Entities;
using AlanTuring.Models;
using AlanTuring.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace AlanTuring
{
    public class Startup
    {
        private CookiePolicyOptions cookiePolicyOptions;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Alan_TuringContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("Alan_Turing")));

            services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings"));
            services.AddSingleton<IMailer, Mailer>();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
           
            services.AddAuthentication("CookieAuthentication")
                  .AddCookie("CookieAuthentication", config =>
                  {
                      config.Cookie.Name = "UserLoginCookie";
                      //config.LoginPath = "/Login/UserLogin";
                  });

            services.AddControllers();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
          
            app.UseAuthentication();
            app.UseRouting();
           
            app.UseAuthorization();
            
            app.UseSession();
            

            app.UseEndpoints(endpoints =>
            {
               // endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
