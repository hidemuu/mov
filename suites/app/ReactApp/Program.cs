using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.OpenApi.Models;
using Mov.Suite.ReactApp;

public class Program
{

    #region main method

    public static void Main(string[] args)
    {
        var app = Build(WebApplication.CreateBuilder(args));
        Setup(app);
        app.Run();
        //CreateHostBuilder(args).Build().Run();
    }

    #endregion main method

    #region private method

    private static WebApplication Build(WebApplicationBuilder builder)
    {
        // Add services to the container.
        var services = builder.Services;
        services.AddControllersWithViews();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mov", Version = "v1" });
        });
        //In production, the React files will be served from this directory
        services.AddSpaStaticFiles(configuration =>
        {
            configuration.RootPath = "ClientApp/build";
        });

        //var db = new ApiDbContext(new DbContextOptionsBuilder<ApiDbContext>()
        //    .UseSqlite(Urls.SqlLocalConnectionStringForSqlite).Options);
        //services.AddScoped<IConfiguratorRepository, FileConfiguratorRepository>(_ => new FileConfiguratorRepository(PathCreator.GetResourcePath(), "", AccessConstants.PATH_EXTENSION_JSON));
        services.AddMvc();

        return builder.Build();
    }

    private static void Setup(WebApplication app)
    {
        var env = app.Environment;

        // Configure the HTTP request pipeline.
        if (!env.IsDevelopment())
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
        else
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mov v1"));
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseSpaStaticFiles();

        app.UseRouting();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action=Index}/{id?}");

        app.MapFallbackToFile("index.html");

        app.UseSpa(spa =>
        {
            spa.Options.SourcePath = "ClientApp";
            if (env.IsDevelopment())
            {
                spa.UseReactDevelopmentServer(npmScript: "start");
            }
        });
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

    #endregion private method
}