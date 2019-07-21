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
using Swashbuckle.AspNetCore.Swagger;
using AirboxInterview.LocationService.Interfaces;
using AirboxInterview.LocationService.Repositories;
using Microsoft.EntityFrameworkCore;
using AirboxInterview.LocationService.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using AirboxInterview.LocationService.Services;

namespace AirboxInterview.LocationService
{
    public class Startup
    {
        const string ApiName = "Location API";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer();
            services.AddMvc(config => 
            {
                config.RespectBrowserAcceptHeader = true;
                config.InputFormatters.Add(new XmlSerializerInputFormatter());
                config.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            });

            var connection = Configuration.GetConnectionString("ConnectionString");
            
            services.AddDbContext<UserLocationContext>
                (options => options.UseSqlServer(connection));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {

                    Version = "v1",
                    Title = ApiName,
                    Description = "API for retrieving user locations",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Jacob Weddell" }

                });

            });

            services.AddTransient<IUserLocationRepository, UserLocationRepository>();
            services.AddTransient<IUserLocationService, UserLocationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", ApiName);
            });

            app.UseMvc();
        }
    }
}
