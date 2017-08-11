using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using tinc.Web.Infrastructure;
using Swashbuckle.AspNetCore.Swagger;

//using Swashbuckle.AspNetCore.Swagger;




namespace tinc.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<tinc.Repository.Context.RepositoryContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Db"));
            });
            // Add framework services.
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "tinc API", Version = "v1" });
            });
            RegisterServicesForStartup.RegisterServices(services, Configuration.GetConnectionString("Db"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<Repository.Context.RepositoryContext>().Database.Migrate();
            }

            var supportedCultures = new[]
          {
               new CultureInfo("pt-PT"), new CultureInfo("en")
             };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pt"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
                c.RoutePrefix = "swagger";
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                  //  template: "web/{controller=Home}/{action=Index}/{id:Guid?}&{_id:Guid?}");
                template: "web/{controller=Home}/{action=Index}/{id:Guid?}");
                //template: "web/{controller=Home}/{action=Index}/{id:Guid?}/{_id:Guid?}");

                //routes.MapRoute(
                //    name: "EditSkillEvaluation",
                //    template: "web/EvaluateCandidate/Edit/{evaluationid}&{skillid}",
                //    defaults: new
                //    {
                //        controller="EvaluateCandidate",
                //        action = "Edit",
                //        evaluationid= @"\d+",
                //        skillid = @"\d+"

                //    });
            });
        }
    }
}
