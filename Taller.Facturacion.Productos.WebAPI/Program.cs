using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Taller.Facturacion.Productos.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {

            var configSettings = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(configSettings["Logging:LogPath"], rollOnFileSizeLimit: true, fileSizeLimitBytes: 1024)
                .CreateLogger();

            return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(config =>
            {
                config.AddConfiguration(configSettings);
            })
            .ConfigureLogging(logging =>
            {
                logging.AddSerilog();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

            //return Host.CreateDefaultBuilder(args)
            //       .ConfigureWebHostDefaults(webBuilder =>
            //       {
            //           webBuilder.UseStartup<Startup>();
            //       });
        }




        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
