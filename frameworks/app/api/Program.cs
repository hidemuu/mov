using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Mov.Analizer.Models;
using Mov.Analizer.Repository;
using Mov.Core.Accessors.Models;
using Mov.Core.Configurators;
using Mov.Core.Configurators.Contexts;
using Mov.Core.Configurators.Repositories;
using Mov.Core.Translators;
using Mov.Core.Translators.Contexts;
using Mov.Core.Translators.Repositories;
using Mov.Designer.Models;
using Mov.Designer.Repository;
using Mov.Framework.Services;
using System.Reflection;

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

var coreResourcePath = PathValue.Factory.CreateResourceRootPath("mov");
services.AddScoped<IConfiguratorRepository, FileConfiguratorRepository>(_ => new FileConfiguratorRepository(coreResourcePath.Value, FileType.Json, EncodingValue.UTF8));
//services.AddScoped<ITranslatorRepository, FileTranslatorRepository>(_ => new FileTranslatorRepository(resourcePath.Value));
var translatorDbPath = PathValue.Factory.CreateResourcePath("mov", @"translator.sqlite").GetSqliteConnectionString();
var translatorDbContextBuilder = new DbContextOptionsBuilder<TranslatorDbContext>()
    .UseSqlite(translatorDbPath);
services.AddScoped<ITranslatorRepository, SqlTranslatorRepository>(_ => new SqlTranslatorRepository(translatorDbContextBuilder));

var resourcePath = PathCreator.GetResourcePath();
ConfiguratorContext.Initialize(resourcePath);
services.AddScoped<ITranslatorRepository, FileTranslatorRepository>(_ => new FileTranslatorRepository(resourcePath));
services.AddScoped<IAnalizerRepository, FileAnalizerRepository>(_ => new FileAnalizerRepository(resourcePath));
services.AddScoped<IDesignerRepository, FileDesignerRepository>(_ => new FileDesignerRepository(resourcePath, FileType.Xml, EncodingValue.UTF8));
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
