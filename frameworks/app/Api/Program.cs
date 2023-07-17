using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Mov.Core.Configurators.Repositories;
using Mov.Core.Configurators;
using System.Reflection;
using Mov.Framework.Creators;
using Mov.Core;
using Mov.Core.Models.Texts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var service = builder.Services;
service.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
service.AddEndpointsApiExplorer();
service.AddSwaggerGen(option =>
{
    // XMLファイルのパスを取得
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    // XMLファイルをドキュメントコメントとして登録
    option.IncludeXmlComments(xmlPath);
    option.SwaggerDoc("mov", new OpenApiInfo { Title = "Mov", Version = "v1" });
});

var resourcePath = PathCreator.GetResourcePath();
service.AddScoped<IConfiguratorRepository, FileConfiguratorRepository>(_ => new FileConfiguratorRepository(resourcePath, FileType.Json, EncodingValue.UTF8));
service.AddMvc();

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
