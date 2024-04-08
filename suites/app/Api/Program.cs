using Microsoft.OpenApi.Models;
using Mov.Core.Configurators.Contexts;
using Mov.Framework.Services;
using Mov.Suite.AnalizerClient.Resas.Repository;
using Mov.Suite.AnalizerClient.Resas;
using System.Reflection;
using Mov.Analizer.Models;
using Mov.Analizer.Repository;
using Mov.Analizer.Service;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddCors(options =>
{
	options.AddPolicy(
		"AllowAll",
		policy =>
		{
			policy.AllowAnyOrigin()   // すべてのオリジンからのアクセスを許可
				   .AllowAnyMethod()
				   .AllowAnyHeader();
		});
});
services.AddCors(options =>
{
	options.AddPolicy("AllowSpecificOrigin",
		policy =>
		{
			policy.WithOrigins("http://localhost:3000", "http://localhost:5257")
				.AllowAnyMethod()
				.AllowAnyHeader();
		});
});
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(option =>
{
    // XMLファイルのパスを取得
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    // XMLファイルをドキュメントコメントとして登録
    option.IncludeXmlComments(xmlPath);
    option.SwaggerDoc("mov_suite", new OpenApiInfo { Title = "Mov Suite", Version = "v1" });
});

//フレームワークサービス登録
var resourcePath = PathCreator.GetResourcePath();
services.AddScoped<IAnalizerRepository, FileAnalizerRepository>(_ => new FileAnalizerRepository(resourcePath));
//クライアントサービス登録
ConfiguratorContext.Initialize(resourcePath);
var apis = ConfiguratorContext.Current.Service.ApiSettingQuery.Reader.ReadAll().ToArray();
var resasApi = apis.FirstOrDefault(x => x.Code.Value.Equals("RESAS-API-KEY"));
services.AddScoped<IResasRepository, RestResasRepository>(_ => new RestResasRepository(resasApi?.Value));
services.AddScoped<IRegionAnalizerClient, ResasAnalizerClient>();
services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	//開発環境
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI(option =>
	{
		option.SwaggerEndpoint("/swagger/mov_suite/swagger.json", "Mov Suite APIs sandbox.");
	});
}
else
{
	//本番環境の場合は、Swagger UIを無効化
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

app.UseCors("AllowAll");
//app.UseCors("AllowSpecificOrigin"); // CORS middleware

app.UseStaticFiles();
//app.UseStaticFiles(new StaticFileOptions
//{
//	FileProvider = new PhysicalFileProvider(
//		Path.Combine(Directory.GetCurrentDirectory(), "UploadFiles")),
//	RequestPath = "/UploadFiles"
//});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();