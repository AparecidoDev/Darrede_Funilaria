using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API_Mockada
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
             //serviços dos controllers
             .AddControllers()


             .AddNewtonsoftJson(options =>
             {
                    // Ignora os loopings
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                    // Ignora os valores nulos ao fazer joins nas consultas
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
             });

            // Adiciona o CORS ao projeto
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                    builder => {
                        builder.WithOrigins("http://localhost:3000", "http://localhost:5000", "http://localhost:19006", "http://localhost:19002", "http://doisirmaosdarede.s3-website-us-east-1.amazonaws.com")
                                                                    .AllowAnyHeader()
                                                                    .AllowAnyMethod()
                                                                    .AllowCredentials();

                    }
                );
            });

            //swegger
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FunilariaDev-ApiMockada-Sinesp", Version = "v1" });


                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("http://localhost:5001/swagger/v1/swagger.json", "FunilariaDev-ApiMockada-Sinesp");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });

        }
    }
}
