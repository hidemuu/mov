using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Mov.AspReact
{
    public class Startup
    {

        #region property
        public IConfiguration Configuration { get; }

        #endregion property

        #region constructor

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        #endregion constructor

        #region method

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mov", Version = "v1" });
            });

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            //var db = new ApiDbContext(new DbContextOptionsBuilder<ApiDbContext>()
            //    .UseSqlite(Urls.SqlLocalConnectionStringForSqlite).Options);
            //services.AddScoped<IInfectionRepository, SqlInfectionRepository>(_ => new SqlInfectionRepository(db));
            //services.AddScoped<IInspectionRepository, SqlInspectionRepository>(_ => new SqlInspectionRepository(db));
            //services.AddScoped<IChartItemRepository, SqlChartItemRepository>(_ => new SqlChartItemRepository(db));
            //services.AddScoped<IChartConfigRepository, SqlChartConfigRepository>(_ => new SqlChartConfigRepository(db));
            //services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mov v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapFallbackToFile("index.html");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }

        #endregion method
    }
}
