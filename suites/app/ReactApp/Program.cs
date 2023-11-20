using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.OpenApi.Models;
using Mov.Analizer.Models;
using Mov.Analizer.Repository;
using Mov.Analizer.Service;
using Mov.Core.Configurators.Contexts;
using Mov.Framework.Services;
using Mov.Suite.AnalizerClient.Resas;
using Mov.Suite.AnalizerClient.Resas.Repository;
using Mov.Suite.ReactApp;

public class Program
{

    #region main method

    public static void Main(string[] args)
    {
        var app = Build(WebApplication.CreateBuilder(args));
        Setup(app);
        app.Run();
    }

    #endregion main method

    #region private method

    private static WebApplication Build(WebApplicationBuilder builder)
    {
		builder.Services.AddAuthentication(
		    CertificateAuthenticationDefaults.AuthenticationScheme)
	        .AddCertificate();

		// Add services to the container.
		var services = builder.Services;
        services.AddControllersWithViews();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mov_Suite_React", Version = "v1" });
        });
        //In production, the React files will be served from this directory
        services.AddSpaStaticFiles(configuration =>
        {
            configuration.RootPath = "ClientApp/build";
        });

		var resourcePath = PathCreator.GetResourcePath();
		services.AddScoped<IAnalizerRepository, FileAnalizerRepository>(_ => new FileAnalizerRepository(resourcePath));
		ConfiguratorContext.Initialize(resourcePath);
        var apis = ConfiguratorContext.Current.Service.ApiSettingQuery.Reader.ReadAll().ToArray();
        var resasApi = apis.FirstOrDefault(x => x.Code.Value.Equals("RESAS-API-KEY"));
        //var db = new ApiDbContext(new DbContextOptionsBuilder<ApiDbContext>()
        //    .UseSqlite(Urls.SqlLocalConnectionStringForSqlite).Options);
        services.AddScoped<IResasRepository, RestResasRepository>(_ => new RestResasRepository(resasApi?.Value));
		services.AddScoped<IRegionAnalizerClient, ResasAnalizerClient>();
		services.AddMvc();

        return builder.Build();
    }

    private static void Setup(WebApplication app)
    {
		app.UseAuthentication();

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
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mov Suite React v1"));
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseSpaStaticFiles();

        app.UseRouting();

        //app.MapControllers();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action=Index}/{id?}");

        app.MapFallbackToFile("index.html");

        //app.UseSpa(spa =>
        //{
        //    spa.Options.SourcePath = "ClientApp";
        //    if (env.IsDevelopment())
        //    {
        //        spa.UseReactDevelopmentServer(npmScript: "start");
        //    }
        //});
    }

    #endregion private method
}