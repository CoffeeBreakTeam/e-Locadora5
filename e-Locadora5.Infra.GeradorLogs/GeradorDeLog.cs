using Serilog;
using Serilog.Core;
using System;

namespace e_Locadora5.Infra.GeradorLogs
{
    public static class GeradorDeLog
    {

        public static void ConfigurarLog()
        {
            Logger logger = new LoggerConfiguration()
               .WriteTo.Seq("http://20.206.137.196:5341")
               .WriteTo.File("C:\\Users\\Cliente\\Desktop\\Locadora\\e-Locadora5\\e-Locadora5.Infra.Log\\bin\\Debug\\net5.0\\log-.txt", rollingInterval: RollingInterval.Day)
               .CreateLogger();
            Serilog.Log.Logger = logger;
        }

    }
}
