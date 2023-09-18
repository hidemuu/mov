using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Mov.Core.Accessors.Models;
using Mov.Core.Configurators;
using Mov.Core.Configurators.Repositories;
using Mov.Core.Models;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Services;
using Mov.Core.Translators;
using Mov.Core.Translators.Contexts;
using Mov.Core.Translators.Models.Schemas;
using Mov.Core.Translators.Repositories;
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
    option.SwaggerDoc("mov_core", new OpenApiInfo { Title = "Mov Core", Version = "v1" });
});

var resourcePath = PathValue.Factory.CreateResourceRootPath("mov");
services.AddScoped<IConfiguratorRepository, FileConfiguratorRepository>(_ => new FileConfiguratorRepository(resourcePath.Value, FileType.Json, EncodingValue.UTF8));
//services.AddScoped<ITranslatorRepository, FileTranslatorRepository>(_ => new FileTranslatorRepository(resourcePath.Value));
var translatorDbPath = PathValue.Factory.CreateResourcePath("mov", @"translator.sqlite").GetSqliteConnectionString();
var translatorDbContextBuilder = new DbContextOptionsBuilder<TranslatorDbContext>()
    .UseSqlite(translatorDbPath);
services.AddScoped<ITranslatorRepository, SqlTranslatorRepository>(_ => new SqlTranslatorRepository(translatorDbContextBuilder));
//services.AddScoped<IDbRepository<TranslateSchema, int>, SqlDbRepository<TranslateSchema, int>>(_ => new SqlDbRepository<TranslateSchema, int>(translatorDb, translatorDb.Translates));

services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
app.UseSwaggerUI(option =>
{
    option.SwaggerEndpoint("/swagger/mov_core/swagger.json", "Mov Core APIs sandbox.");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();