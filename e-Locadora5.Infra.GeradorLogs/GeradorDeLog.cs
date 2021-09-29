
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Exceptions;
using System.IO;

namespace e_Locadora5.Infra.GeradorLogs
{
    public static class GeradorDeLog
    {

        public static void ConfigurarLog()
        {
            var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", false, true)
           .Build();

            var levelSwitch = new LoggingLevelSwitch();

            Logger logger = new LoggerConfiguration()
               .ReadFrom.Configuration(configuration)
               .MinimumLevel.ControlledBy(levelSwitch)
               .WriteTo.Seq("http://localhost:5341/", controlLevelSwitch: levelSwitch)
               .Enrich.WithExceptionDetails()               
               .WriteTo.File(Directory.GetCurrentDirectory(), rollingInterval: RollingInterval.Day)
               .CreateLogger();

            Serilog.Log.Logger = logger;
            
        }

    }
}
