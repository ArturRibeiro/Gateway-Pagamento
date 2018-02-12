using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Scorponok.Adquirente.Web.UI.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            switch (env.EnvironmentName)
            {
                case "Integration.Test": ConfiguraAmbienteDeTest(app, env); break;
                case "Development": ConfiguraAmbienteDeDesenvolvimento(app, env); break;
                default:
                    throw new NotImplementedException($"Não existe ambiente configurado: {env.EnvironmentName}");
            }

            app.UseMvc();
        }

        private void ConfiguraAmbienteDeTest(IApplicationBuilder app, IHostingEnvironment env)
        {
            //throw new NotImplementedException();
        }

        private void ConfiguraAmbienteDeDesenvolvimento(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
        }
    }
}
