using Serilog;
using Serilog.Core;
using System;

namespace e_Locadora5.Infra.Log
{
    public class LogSeq
    {
        public bool EnviarLog(string mensagem)
        {
            try
            {
                using (var logger = BuildSerilog())
                    logger.Information(mensagem);
                return true;
            }
            catch 
            { 
                return false;
            }
        }

        private Logger BuildSerilog()
        {
            var logger = new LoggerConfiguration()
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();
            Serilog.Log.Logger = logger;

            return logger;
        }
    }
}
