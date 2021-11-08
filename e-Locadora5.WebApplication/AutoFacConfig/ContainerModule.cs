using Autofac;
using AutoMapper;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Locadora5.WebApplication.AutoFacConfig
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LocadoraDbContext>().InstancePerLifetimeScope();

            builder.RegisterType<ParceiroOrmDAO>().As<IParceiroRepository>();

            builder.RegisterType<Mapper>().As<IMapper>();
        }

    }
}
