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

        }

        private static void RegistrarAppService(ContainerBuilder containerbuilder)
        {
            containerbuilder.RegisterType<ParceiroAppService>().InstancePerDependency();
            containerbuilder.RegisterType<GrupoVeiculoAppService>().InstancePerDependency();
            containerbuilder.RegisterType<VeiculoAppService>().InstancePerDependency();
        }

     

        private static void RegistraOperacoes(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<OperacoesParceiros>().InstancePerDependency();
            containerBuilder.RegisterType<OperacoesGrupoVeiculo>().InstancePerDependency();
            containerBuilder.RegisterType<OperacoesVeiculo>().InstancePerDependency();
        }
    }
}
