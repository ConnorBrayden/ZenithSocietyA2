using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ZenithSocietyA2.Data;
using ZenithSocietyA2.Models;
using ZenithSocietyA2.Services;

namespace ZenithSocietyA2
{
    public class Startup
    {
//        
//        public List<IRequestCultureProvider> RequestCultureProviders { get; private set; }
//        
        
        private List<CultureInfo> supportedCultures = new List<CultureInfo>
        {
//            new CultureInfo("en"),
            new CultureInfo("en-US"),
//            new CultureInfo("fr"),
            new CultureInfo("fr-FR")
        };
        
        private RequestCulture defaultCulture = new RequestCulture("en-US");

                
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddUserManager<UserManager<ApplicationUser>>();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();


//			services.AddIdentity<Entities.DB.User, IdentityRole<int>>()
//                .AddEntityFrameworkStores<MyDBContext, int>();

			//services.AddScoped<RoleManager<IdentityRole>>();


            services.AddLocalization(options => options.ResourcesPath = "Resources");
            
            
            
            services.AddMvc()
                
                .AddViewLocalization(
                    LanguageViewLocationExpanderFormat.Suffix,
                    opts =>
                    {
                        opts.ResourcesPath = "Resources";
                    })
                .AddDataAnnotationsLocalization();

            services.Configure<RequestLocalizationOptions>(opts =>
            {


                opts.DefaultRequestCulture = defaultCulture;
                opts.SupportedCultures = supportedCultures;

                opts.SupportedUICultures = supportedCultures;
                
          

            });
            
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {

            app.UseRequestLocalization();
            
            app.UseCors("MyPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
             
                app.UseExceptionHandler("/Home/Error");
            }


            //var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();


//            var options = new RequestLocalizationOptions
//            {
//                DefaultRequestCulture = defaultCulture,
//                SupportedCultures = supportedCultures
//            };
//
//            app.UseRequestLocalization(options);
            
            app.UseStaticFiles();

            
            //app.UseRequestLocalization(app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value);
            
           

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            context.Database.Migrate();

            Seed.SeedRoles(roleManager, userManager, context);
			Seed.SeedEvents(context);


        }
    }
}
