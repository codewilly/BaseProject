using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProject.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string _environment = new WebHostBuilder().GetSetting("environment");

            IConfigurationRoot _config =
                new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{_environment}.json", optional: true, reloadOnChange: true)
                    .Build();

            Serilog.Debugging.SelfLog.Enable(Console.WriteLine);

            Log.Logger =
                new LoggerConfiguration()
                    .ReadFrom.Configuration(_config)
                             .CreateLogger();

            try
            {
                if (string.IsNullOrEmpty(_environment) && Debugger.IsAttached)
                    Log.Warning("You are {warnMessage}!", "DEBUGING IN PRODUCTION MODE");

                Log.Information("Application started - {environment}", _environment);

                CreateHostBuilder(args)
                    .Build()
                    .Run();
            }
            catch (Exception exception)
            {
                Log.Fatal(exception, "Failed to start application: {message}", exception.Message);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
