using e_Locadora5.Infra.InternetServices;
using Serilog;
using Serilog.Core;
using Serilog.Exceptions;
using Serilog.Exceptions.Core;
using System;

namespace e_Locadora5.Infra.Log
{
    public static class GeradorDeLog
    {
      
        public static void ConfigurarLog()
        {
            Logger logger = new LoggerConfiguration()
               .Enrich.WithExceptionDetails()
               .WriteTo.Seq("http://localhost:5341")
               .WriteTo.File("C:\\Users\\Cliente\\Desktop\\Locadora\\e-Locadora5\\e-Locadora5.Infra.Log\\bin\\Debug\\net5.0\\log-.txt", rollingInterval: RollingInterval.Day)
               .CreateLogger();
               Serilog.Log.Logger = logger;
        }

    }
}
