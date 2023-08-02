using Microsoft.OpenApi.Models;
using Mov.Core.Configurators.Repositories;
using Mov.Core.Configurators;
using Mov.Core.Models.Texts;
using Mov.Core.Translators.Repositories;
using Mov.Core.Translators;
using System.Reflection;
using Mov.Core.Models.Connections;

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
services.AddScoped<ITranslatorRepository, FileTranslatorRepository>(_ => new FileTranslatorRepository(resourcePath.Value));
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