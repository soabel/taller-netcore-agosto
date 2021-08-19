using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Taller.Facturacion.Productos.Application.Services;
using Taller.Facturacion.Productos.Application.Services.Contracts;
using Taller.Facturacion.Productos.Domain.Repositories;
using Taller.Facturacion.Productos.Domain.Services;
using Taller.Facturacion.Productos.Domain.Services.Contracts;
using Taller.Facturacion.Productos.Infraestructure.Core.Exceptions;
using Taller.Facturacion.Productos.Infraestucture.Persistence;
using Taller.Facturacion.Productos.Infraestucture.Persistence.Repositories;

namespace Taller.Facturacion.Productos.WebAPI
{
    public class Startup
    {
        private object configSettings;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(configuration["Logging:LogPath"], rollOnFileSizeLimit: true, fileSizeLimitBytes: 1024)
                .CreateLogger();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: RESTRINGIR A ORIGENES ESPECIFICOS
            services.AddCors(options =>
            {
                options.AddPolicy(name: "misOrigenes",
                    builder =>
                    {
                        builder.WithOrigins("*")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                    });
            });

            //services.AddSingleton<IProductoService, ProductoService>();
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            //services.AddTransient<IProductoService, ProductoService>();

            services.AddScoped<IProductoDomain, ProductoDomain>();

            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            var connectionString = Configuration.GetConnectionString("DatabaseConnection");

            services.AddDbContext<DatabaseContext>(options =>
               options.UseSqlServer(connectionString), ServiceLifetime.Transient);

            services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());


        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,  ILogger<Startup> logger, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddSerilog();

            logger.LogInformation("Mensaje Information");
            logger.LogCritical("Mensaje Critical");
            logger.LogDebug("Mensaje Debug");
            logger.LogError("Mensaje Error");
            logger.LogTrace("Mensaje Trace");
            logger.LogWarning("Mensaje Warning");

            logger.LogInformation($"MyKey : {Configuration["MyKey"]}");


            //app.UseExceptionHandler(appError =>
            //{
            //    appError.Run(async context =>
            //    {
            //        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //        context.Response.ContentType = "application/text";
            //        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
            //        if (contextFeature != null)
            //        {
            //            await context.Response.WriteAsync("Ha ocurrido un error");
            //        }
            //    });
            //});

            app.ConfigureExceptionHandler(logger);


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

        }
    }
}
