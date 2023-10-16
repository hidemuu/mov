using Microsoft.OpenApi.Models;
using Mov.Core.Configurators.Contexts;
using Mov.Framework.Services;
using Mov.Suite.AnalizerClient.Resas.Repository;
using Mov.Suite.AnalizerClient.Resas;
using System.Reflection;
using Mov.Analizer.Models;
using Mov.Analizer.Repository;
using Mov.Analizer.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
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
    option.SwaggerDoc("mov", new OpenApiInfo { Title = "Mov", Version = "v1" });
});

//フレームワークサービス登録
var resourcePath = PathCreator.GetResourcePath();
services.AddScoped<IAnalizerRepository, FileAnalizerRepository>(_ => new FileAnalizerRepository(resourcePath));
//クライアントサービス登録
ConfiguratorContext.Initialize(PathCreator.GetResourcePath());
var apis = ConfiguratorContext.Current.Service.ApiSettingQuery.Reader.ReadAll().ToArray();
var resasApi = apis.FirstOrDefault(x => x.Code.Value.Equals("RESAS-API-KEY"));
services.AddScoped<IResasRepository, RestResasRepository>(_ => new RestResasRepository(resasApi?.Value));
services.AddScoped<IRegionAnalizerClient, ResasAnalizerClient>();
services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
app.UseSwaggerUI(option =>
{
    option.SwaggerEndpoint("/swagger/mov/swagger.json", "Mov APIs sandbox.");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();