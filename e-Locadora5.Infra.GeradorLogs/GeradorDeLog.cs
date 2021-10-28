
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
            var levelSwitch = new LoggingLevelSwitch(Serilog.Events.LogEventLevel.Verbose);                 
           
            Logger logger = new LoggerConfiguration()   
            .MinimumLevel.ControlledBy(levelSwitch)
            .WriteTo.Seq("http://20.206.108.144:5341/", apiKey: "8LhLsquJdGeHyPIqbGF5", controlLevelSwitch: levelSwitch)
            .Enrich.WithExceptionDetails()               
            .WriteTo.File(Directory.GetCurrentDirectory(), rollingInterval: RollingInterval.Day)
            .CreateLogger();
            
            Serilog.Log.Logger = logger.Contexto();

        }

    }
}
