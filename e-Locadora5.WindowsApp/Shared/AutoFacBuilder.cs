using Autofac;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using e_Locadora5.Infra.ORM.LocadoraModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using e_Locadora5.WindowsApp.Features.ParceirosModule;
using e_Locadora5.Aplicacao.ParceiroModule;
using e_Locadora5.Infra.ORM.ClienteModule;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Aplicacao.ClienteModule;
using e_Locadora5.WindowsApp.ClientesModule;
using e_Locadora5.Infra.ORM.CupomModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Aplicacao.CupomModule;
using e_Locadora5.WindowsApp.Features.CuponsModule;
using e_Locadora5.Aplicacao.CondutorModule;
using e_Locadora5.WindowsApp.Features.CondutorModule;
using e_Locadora5.Infra.ORM.CondutorModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Infra.ORM.GrupoVeiculoModule;
using e_Locadora5.Dominio.GrupoVeiculoModule;
using e_Locadora5.Aplicacao.GrupoVeiculoModule;
using e_Locadora5.WindowsApp.GrupoVeiculoModule;
using e_Locadora5.Infra.ORM.VeiculoModule;
using e_Locadora5.Dominio.VeiculosModule;
using e_Locadora5.Aplicacao.VeiculoModule;
using e_Locadora5.WindowsApp.VeiculoModule;

namespace e_Locadora5.WindowsApp.Shared
{
    public static class AutoFacBuilder
    {
        public static IContainer Container { get; set; }
        static AutoFacBuilder()
        {
            var Containerbuilder = new ContainerBuilder();

            Containerbuilder.RegisterType<LocadoraDbContext>().InstancePerLifetimeScope();

            RegistrarORM(Containerbuilder);

            RegistrarAppService(Containerbuilder);

            RegistraOperacoes(Containerbuilder);

            Container = Containerbuilder.Build();
        }

        private static void RegistrarORM(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ParceiroOrmDAO>().As<IParceiroRepository>().InstancePerDependency();

            containerBuilder.RegisterType<GrupoVeiculoOrmDAO>().As<IGrupoVeiculoRepository>().InstancePerDependency();
            containerBuilder.RegisterType<VeiculoOrmDAO>().As<IVeiculoRepository>().InstancePerDependency();
            containerBuilder.RegisterType<ClienteOrmDAO>().As<IClienteRepository>().InstancePerDependency();

            containerBuilder.RegisterType<CupomOrmDAO>().As<ICupomRepository>().InstancePerDependency();

            containerBuilder.RegisterType<CondutorOrmDAO>().As<ICondutorRepository>().InstancePerDependency();
        }

        private static void RegistrarAppService(ContainerBuilder containerbuilder)
        {
            containerbuilder.RegisterType<ParceiroAppService>().InstancePerDependency();
            containerbuilder.RegisterType<GrupoVeiculoAppService>().InstancePerDependency();
            containerbuilder.RegisterType<VeiculoAppService>().InstancePerDependency();

            containerbuilder.RegisterType<ClienteAppService>().InstancePerDependency();

            containerbuilder.RegisterType<CupomAppService>().InstancePerDependency();

            containerbuilder.RegisterType<CondutorAppService>().InstancePerDependency();
        }

     

        private static void RegistraOperacoes(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<OperacoesParceiros>().InstancePerDependency();
            containerBuilder.RegisterType<OperacoesGrupoVeiculo>().InstancePerDependency();
            containerBuilder.RegisterType<OperacoesVeiculo>().InstancePerDependency();

            containerBuilder.RegisterType<OperacoesClientes>().InstancePerDependency();

            containerBuilder.RegisterType<OperacoesCupons>().InstancePerDependency();

            containerBuilder.RegisterType<OperacoesCondutores>().InstancePerDependency();
        }
    }
}
