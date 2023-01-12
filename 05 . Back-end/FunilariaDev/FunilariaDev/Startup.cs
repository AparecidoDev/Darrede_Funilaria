using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FunilariaDev
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {                                                                       //C:\\Users\\fic\\Desktop\\cred\\funilariadev.json
                                                                                //C:\\Users\\Enzzo Lima\\OneDrive\\Área de Trabalho\\cred\\funilariadev.json
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "C:\\Users\\fic\\Desktop\\cred\\funilariadev.json");

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
                        builder.WithOrigins("http://localhost:3000", "http://localhost:5000", "http://localhost:19006", "http://localhost:19002")
                                                                    .AllowAnyHeader()
                                                                    .AllowAnyMethod()
                                                                    .AllowCredentials();

                    }
                );
            });

            //swegger
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FunilariaDev", Version = "v1" });


                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
               });


            // final Swagger

 

            // Validação do Token =========

            services
               // Define a forma de autenticação
               .AddAuthentication(options =>
               {
                   options.DefaultAuthenticateScheme = "JwtBearer";
                   options.DefaultChallengeScheme = "JwtBearer";
               })

               // Define os parâmetros de validação do Token
               .AddJwtBearer("JwtBearer", options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       // Quem está emitindo (solicitando)
                       ValidateIssuer = true,
                       // Quem está recebendo
                       ValidateAudience = true,
                       // Tempo de expiração
                       ValidateLifetime = true,
                       // Forma de criptografia e a chave de acesso
                       IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("funilariaDev-chave-acesso")),
                       // Tempo de expiração do token
                       ClockSkew = TimeSpan.FromMinutes(30),
                       // Nome do issuer, de onde está vindo
                       ValidIssuer = "FunilariaDev",
                       // Nome do audience, para onde está indo
                       ValidAudience = "FunilariaDev"
                   };
               });
            // final da validação do token

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FunilariaDev");
                //c.RoutePrefix = string.Empty;
            });

           
             app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                      Path.Combine(Directory.GetCurrentDirectory(), "Resources")),
               RequestPath = "/Resources"
            });
           

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors("CorsPolicy"); 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
