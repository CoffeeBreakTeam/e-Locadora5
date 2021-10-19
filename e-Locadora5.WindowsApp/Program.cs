using e_Locadora5.Dominio;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Dominio.GrupoVeiculoModule;
using e_Locadora5.Dominio.VeiculosModule;
using e_Locadora5.Infra.GeradorLogs;
using e_Locadora5.Infra.ORM.ClienteModule;
using e_Locadora5.Infra.ORM.CondutorModule;
using e_Locadora5.Infra.ORM.FuncionarioModule;
using e_Locadora5.Infra.ORM.GrupoVeiculoModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
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

            GerarObjetosParaAlocar();

            GeradorDeLog.ConfigurarLog();
            TelaLogin telaLogin = new TelaLogin();
            telaLogin.ShowDialog();


        }

        public static void GerarObjetosParaAlocar()
        {
            LocadoraDbContext locadoraDbContextVeiculos = new LocadoraDbContext();

            IGrupoVeiculoRepository grupoVeiculoRepository = new GrupoVeiculoOrmDAO(locadoraDbContextVeiculos);
            var GrupoDeVeiculo = new GrupoVeiculo("SUV",100,100,100,1000,100,200);
            grupoVeiculoRepository.InserirNovo(GrupoDeVeiculo);

            LocadoraDbContext locadoraDbContextFuncionario = new LocadoraDbContext();

            IFuncionarioRepository funcionarioRepositoy = new FuncionarioOrmDAO(locadoraDbContextFuncionario);
            Funcionario funcionario = new Funcionario("Juca","12312312","a","a",DateTime.Now.Date,1000);
            funcionarioRepositoy.InserirNovo(funcionario);

            LocadoraDbContext locadoraDbContextCliente = new LocadoraDbContext();

            IClienteRepository clienteRepository = new ClienteOrmDAO(locadoraDbContextCliente);
            Cliente cliente = new Cliente("Roberto", "abc", "1231231222", "123123", "12312312", "", "jucao123@gmail.com");
            clienteRepository.InserirNovo(cliente);

            ICondutorRepository condutorRepository = new CondutorOrmDAO(locadoraDbContextCliente);
            Condutor condutor = new Condutor("juca","abc","222222","123133","123123","11122",DateTime.Now.AddDays(10).Date,cliente);
            condutorRepository.InserirNovo(condutor);



        }
    }
}
