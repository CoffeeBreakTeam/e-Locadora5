using e_Locadora5.Infra.Log;
using e_Locadora5.WindowsApp.Features.VeiculoModule;
using e_Locadora5.WindowsApp.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Locadora5.WindowsApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new TelaVeiculoForm());
            //Application.Run(new TelaPrincipalForm());

            //Application.Run(new TelaLogin());

            GeradorDeLog.ConfigurarLog();
            TelaLogin telaLogin = new TelaLogin();
            telaLogin.ShowDialog();


        }
    }
}
