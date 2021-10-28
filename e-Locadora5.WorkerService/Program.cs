using Autofac;
using Autofac.Extensions.DependencyInjection;
using e_Locadora5.Aplicacao.LocacaoModule;
using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Infra.GeradorLogs;
using e_Locadora5.Infra.ORM.LocacaoModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace e_Locadora5.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GeradorDeLog.ConfigurarLog();



            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>((hostContext, builder) =>
                {
                    builder.RegisterType<LocadoraDbContext>().InstancePerLifetimeScope();
                    builder.RegisterType<LocacaoOrmDAO>().As<ILocacaoRepository>().InstancePerDependency();
                    builder.RegisterType<LocacaoAppService>().InstancePerDependency();
                })
               .ConfigureLogging(configure =>
                {
                    configure.AddSerilog();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
