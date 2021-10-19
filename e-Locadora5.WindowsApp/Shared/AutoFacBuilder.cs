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
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Infra.ORM.FuncionarioModule;
using e_Locadora5.Aplicacao.FuncionarioModule;
using e_Locadora5.WindowsApp.Features.FuncionarioModule;
using e_Locadora5.Aplicacao.TaxasServicosModule;
using e_Locadora5.Infra.ORM.TaxasServicosModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.WindowsApp.Features.TaxasServicosModule;
using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Infra.ORM.LocacaoModule;
using e_Locadora5.Aplicacao.LocacaoModule;
using e_Locadora5.WindowsApp.Features.LocacaoModule;

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
            
            
            containerBuilder.RegisterType<FuncionarioOrmDAO>().As<IFuncionarioRepository>().InstancePerDependency();



            containerBuilder.RegisterType<TaxasServicosOrmDAO>().As<ITaxasServicosRepository>().InstancePerDependency();



            containerBuilder.RegisterType<LocacaoOrmDAO>().As<ILocacaoRepository>().InstancePerDependency();

        

        }

        private static void RegistrarAppService(ContainerBuilder containerbuilder)
        {
            containerbuilder.RegisterType<ParceiroAppService>().InstancePerDependency();
            containerbuilder.RegisterType<FuncionarioAppService>().InstancePerDependency();
            containerbuilder.RegisterType<TaxasServicosAppService>().InstancePerDependency();


            containerbuilder.RegisterType<LocacaoAppService>().InstancePerDependency();


        }

     

        private static void RegistraOperacoes(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<OperacoesParceiros>().InstancePerDependency();
            containerBuilder.RegisterType<OperacoesFuncionario>().InstancePerDependency();
            containerBuilder.RegisterType<OperacoesTaxaServicos>().InstancePerDependency();
            containerBuilder.RegisterType<OperacoesLocacao>().InstancePerDependency();
        }
    }
}
