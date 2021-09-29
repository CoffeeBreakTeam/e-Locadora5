using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Exceptions;
using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace e_Locadora5.Infra.GeradorLogs
{
    public static class GeradorDeLog
    {
        public static void ConfigurarLog()
        {
            //string enderecoLog = Configuration.GetSection("EnderecoLog");

            Logger logger = new LoggerConfiguration()
               .Enrich.WithExceptionDetails()
               .WriteTo.Seq("http://localhost:5341")
               //.WriteTo.Seq(enderecoLog)
               .WriteTo.File(Directory.GetCurrentDirectory(), rollingInterval: RollingInterval.Day)                            
               .CreateLogger();
            Serilog.Log.Logger = logger;
        }

        public static void SilenciarLog()
        {
            if (Log.Logger.GetType().FullName == "Serilog.Core.Pipeline.SilentLogger")
            {
                Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().CreateLogger();
                //Log.Logger.Debug("Logger is not configured. Either this is a unit test or you have to configure the logger");
            }
        }
    }
}
