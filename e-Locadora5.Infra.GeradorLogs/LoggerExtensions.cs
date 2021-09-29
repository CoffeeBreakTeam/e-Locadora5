using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.GeradorLogs
{
    public static class LoggerExtensions
    {
        /*public static ILogger Contexto(this ILogger logger,
            [CallerMemberName] string membername = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            return logger
                .ForContext("MemberName", membername)
                .ForContext("FilePath", Path.GetFileNameWithoutExtension(sourceFilePath))
                .ForContext("LineNumber", sourceLineNumber);
        }*/

        public static ILogger Contexto(this ILogger logger,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            return logger
                .ForContext("MemberName", memberName)
                .ForContext("ClassName", Path.GetFileNameWithoutExtension(sourceFilePath))
                .ForContext("LineNumber", sourceLineNumber);
        }

        public static void FuncionalidadeUsada(this ILogger logger)
        {
            Log.Logger.Contexto().Information("Funcionalidade usada");
        }
    }
}
