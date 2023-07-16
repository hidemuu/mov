using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Mov.Core.Accessors;
using Mov.Core.Configurators.Repositories;
using Mov.Core.Configurators;
using Mov.Framework.Creators;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;
using System.Reflection;
using System;

namespace Mov.AspApi
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        #region property

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        #endregion property

        #region constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //services.AddControllers();

            var resourcePath = PathCreator.GetResourcePath();
            services.AddScoped<IConfiguratorRepository, FileConfiguratorRepository>(_ => new FileConfiguratorRepository(resourcePath, "", AccessConstants.PATH_EXTENSION_JSON));

            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                //c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mov.Api", Version = "v1" });
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mov.Api v1");
                //c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapGet("/testGet", () => "This is a GET");
                //endpoints.MapPost("/testPost", () => "This is a POST");
                //endpoints.MapPut("/testPut", () => "This is a PUT");
                //endpoints.MapDelete("/testDelete", () => "This is a DELETE");
            });
        }

        #endregion method
    }
}
