using Autofac;
using Autofac.Extensions.DependencyInjection;
using e_Locadora5.Aplicacao.LocacaoModule;
using e_Locadora5.Dominio;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Dominio.GrupoVeiculoModule;
using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Dominio.VeiculosModule;
using e_Locadora5.Infra.GeradorLogs;
using e_Locadora5.Infra.ORM.ClienteModule;
using e_Locadora5.Infra.ORM.CondutorModule;
using e_Locadora5.Infra.ORM.CupomModule;
using e_Locadora5.Infra.ORM.FuncionarioModule;
using e_Locadora5.Infra.ORM.GrupoVeiculoModule;
using e_Locadora5.Infra.ORM.LocacaoModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using e_Locadora5.Infra.ORM.VeiculoModule;
using e_Locadora5.Infra.SQL;
using e_Locadora5.WindowsApp.Features.VeiculoModule;
using e_Locadora5.WindowsApp.Login;
using e_Locadora5.WindowsApp.Properties;
using e_Locadora5.WorkerService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

            GeradorDeLog.ConfigurarLog();

            LimparTabelasDoBanco();
            GerarObjetosParaAlocar();

            System.Diagnostics.Process.Start(@"..\..\..\..\e-Locadora5.WorkerService\bin\Debug\net5.0\e-Locadora5.WorkerService.exe");

            TelaLogin telaLogin = new TelaLogin();
            telaLogin.ShowDialog();

            //Application.Run(new TelaLogin());
            //CreateHostBuilder(args).Build().Run();

            
        }   

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
            Cliente cliente = new Cliente("Roberto", "abc", "1231231222", "123123", "12312312", "", "joaoboeira@uniplaclages.edu.br");
            clienteRepository.InserirNovo(cliente);

            ICondutorRepository condutorRepository = new CondutorOrmDAO(locadoraDbContextCliente);
            Condutor condutor = new Condutor("juca", "abc", "222222", "123133", "123123", "11122", DateTime.Now.AddDays(10).Date, cliente);
            condutorRepository.InserirNovo(condutor);          

            IVeiculoRepository veiculoRepository = new VeiculoOrmDAO(locadoraDbContextVeiculos);
            Veiculo veiculo = new Veiculo("ETH5000", "Mobi", "Fiat", 10000,50,4,"asdasd","Azul", 5, 20016,"Grande","Gasolina",GrupoDeVeiculo, ConvertImageToBinary(Resources.fundoPictureBoxVeiculo));
            veiculoRepository.InserirNovo(veiculo);

            LocadoraDbContext locadoraDbContextCupom = new LocadoraDbContext();

            IParceiroRepository parceiroRepository = new ParceiroOrmDAO(locadoraDbContextCupom);
            Parceiro parceiro = new Parceiro("Juca");
            parceiroRepository.InserirNovo(parceiro);

            ICupomRepository cupomRepository = new CupomOrmDAO(locadoraDbContextCupom);
            Cupom cupom = new Cupom("DESC10", 0 , 1000, DateTime.Now.AddDays(10).Date,parceiro,10);
            cupomRepository.InserirNovo(cupom);

        }

        static byte[] ConvertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, Resources.fundoPictureBoxVeiculo.RawFormat);
                return ms.ToArray();
            }
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
