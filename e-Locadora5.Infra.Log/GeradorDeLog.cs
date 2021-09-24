using e_Locadora5.Infra.InternetServices;
using Serilog;
using Serilog.Core;
using System;

namespace e_Locadora5.Infra.Log
{
    public class GeradorDeLog
    {
        Logger logger;
        NiveisSerilog niveisSerilog;
        public bool RegistrarLog(string mensagem, NiveisSerilog niveisSerilog)
        {
            this.niveisSerilog = niveisSerilog;

            if (VerificadorInternet.VerificaConexaoDeInternet())
            {
                return EnviarLogParaSeq(mensagem);
            }
            else
            {
                return GravarLogEmtxt(mensagem);
            }
        }

        private void EscreverLog(string mensagem)
        {
            switch (niveisSerilog)
            {
                case NiveisSerilog.Verbose:
                    logger.Verbose(mensagem);
                    break;
                case NiveisSerilog.Debug:
                    logger.Debug(mensagem);
                    break;
                case NiveisSerilog.Information:
                    logger.Information(mensagem);
                    break;
                case NiveisSerilog.Warming:
                    logger.Warning(mensagem);
                    break;
                case NiveisSerilog.Error:
                    logger.Error(mensagem);
                    break;
                case NiveisSerilog.Fatal:
                    logger.Fatal(mensagem);
                    break;                
            }
        }

        private bool GravarLogEmtxt(string mensagem)
        {
            try
            {
                logger = new LoggerConfiguration()
                 .WriteTo.File("C:\\Users\\Cliente\\Desktop\\Locadora\\e-Locadora5\\e-Locadora5.Infra.Log\\bin\\Debug\\net5.0\\log-.txt", rollingInterval: RollingInterval.Day)
                 .CreateLogger();

                EscreverLog(mensagem);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        private bool EnviarLogParaSeq(string mensagem)
        {
            logger = new LoggerConfiguration()
               .WriteTo.Seq("http://localhost:5341")
               .CreateLogger();
               Serilog.Log.Logger = logger;

            try
            {
                using (logger)
                    EscreverLog(mensagem);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
