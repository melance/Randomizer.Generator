using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randomizer.Generator.UI.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
			WebHostEnvironment = environment;
        }

        public IConfiguration Configuration { get; }
		public IWebHostEnvironment WebHostEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
					.AddRazorRuntimeCompilation();
			services.Configure<CookiePolicyOptions>(opt =>
			{
				opt.CheckConsentNeeded = context => true;
				opt.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
			});
			services.AddSession(opt =>
			{
				opt.Cookie.IsEssential = true;
			});
			services.AddSingleton(_ =>
			{
				var rootPath = System.IO.Path.Combine(WebHostEnvironment.WebRootPath);
				return new Utility.MVCDataAccess(rootPath);
			});
			services.AddOptions();
			services.Configure<Utility.Settings>(Configuration.GetSection(Utility.Settings.SectionName));
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
