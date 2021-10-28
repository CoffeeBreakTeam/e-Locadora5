using Autofac;
using Autofac.Extensions.DependencyInjection;
using e_Locadora5.Aplicacao.LocacaoModule;
using e_Locadora5.Dominio;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Dominio.GrupoVeiculoModule;
using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Dominio.VeiculosModule;
using e_Locadora5.Infra.GeradorLogs;
using e_Locadora5.Infra.ORM.ClienteModule;
using e_Locadora5.Infra.ORM.CondutorModule;
using e_Locadora5.Infra.ORM.FuncionarioModule;
using e_Locadora5.Infra.ORM.GrupoVeiculoModule;
using e_Locadora5.Infra.ORM.LocacaoModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using e_Locadora5.Infra.SQL;
using e_Locadora5.WindowsApp.Features.VeiculoModule;
using e_Locadora5.WindowsApp.Login;
using e_Locadora5.WorkerService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
        static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new TelaVeiculoForm());
            //Application.Run(new TelaPrincipalForm());

            //Application.Run(new TelaLogin());

            GeradorDeLog.ConfigurarLog();



            LimparTabelasDoBanco();
            GerarObjetosParaAlocar();

            TelaLogin telaLogin = new TelaLogin();
            telaLogin.ShowDialog();

            //CreateHostBuilder(args).Build().Run();




        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        //        .ConfigureContainer<ContainerBuilder>((hostContext, builder) =>
        //        {
        //            builder.RegisterType<LocadoraDbContext>().InstancePerLifetimeScope();
        //            builder.RegisterType<LocacaoOrmDAO>().As<ILocacaoRepository>().InstancePerDependency();
        //            builder.RegisterType<LocacaoAppService>().InstancePerDependency();
        //        })
        //        .ConfigureServices((hostContext, services) =>
        //        {
        //            services.AddHostedService<Worker>();
        //        });

        public static void GerarObjetosParaAlocar()
        {
            LocadoraDbContext locadoraDbContextVeiculos = new LocadoraDbContext();

            IGrupoVeiculoRepository grupoVeiculoRepository = new GrupoVeiculoOrmDAO(locadoraDbContextVeiculos);
            var GrupoDeVeiculo = new GrupoVeiculo("SUV", 100, 100, 100, 1000, 100, 200);
            grupoVeiculoRepository.InserirNovo(GrupoDeVeiculo);

            LocadoraDbContext locadoraDbContextFuncionario = new LocadoraDbContext();

            IFuncionarioRepository funcionarioRepositoy = new FuncionarioOrmDAO(locadoraDbContextFuncionario);
            Funcionario funcionario = new Funcionario("Juca", "12312312", "a", "a", DateTime.Now.Date, 1000);
            funcionarioRepositoy.InserirNovo(funcionario);

            LocadoraDbContext locadoraDbContextCliente = new LocadoraDbContext();

            IClienteRepository clienteRepository = new ClienteOrmDAO(locadoraDbContextCliente);
            Cliente cliente = new Cliente("Roberto", "abc", "1231231222", "123123", "12312312", "", "jucao123@gmail.com");
            clienteRepository.InserirNovo(cliente);

            ICondutorRepository condutorRepository = new CondutorOrmDAO(locadoraDbContextCliente);
            Condutor condutor = new Condutor("juca", "abc", "222222", "123133", "123123", "11122", DateTime.Now.AddDays(10).Date, cliente);
            condutorRepository.InserirNovo(condutor);



        }

        public static void LimparTabelasDoBanco()
        {
            Db.Update("DELETE FROM LOCACAOTAXASSERVICOS");
            Db.Update("DELETE FROM TBLOCACAO");
            Db.Update("DELETE FROM TBCUPOM");
            Db.Update("DELETE FROM TBPARCEIRO");
            Db.Update("DELETE FROM TBTAXASSERVICOS");
            Db.Update("DELETE FROM TBCONDUTOR");
            Db.Update("DELETE FROM TBCliente");
            Db.Update("DELETE FROM TBFUNCIONARIO");
            Db.Update("DELETE FROM TBVEICULO");
            Db.Update("DELETE FROM TBGRUPOVEICULO");
        }
    }
}
