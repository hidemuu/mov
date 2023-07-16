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

namespace Mov.AspApi
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
            services.AddMvc();
            //services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mov.Api", Version = "v1" });
            });
            var resourcePath = PathCreator.GetResourcePath();
            services.AddScoped<IConfiguratorRepository, FileConfiguratorRepository>(_ => new FileConfiguratorRepository(resourcePath, "", AccessConstants.PATH_EXTENSION_JSON));            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mov.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #endregion method
    }
}
