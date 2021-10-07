using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Infra.ORM.ClienteModule;
using e_Locadora5.Infra.ORM.CondutorModule;
using e_Locadora5.Infra.ORM.CupomModule;
using e_Locadora5.Infra.ORM.FuncionarioModule;
using e_Locadora5.Infra.ORM.VeiculoModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.ParceiroModule
{
    public class LocadoraDbContext : DbContext 
    {
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder                    
                //.UseLazyLoadingProxies()                
                .UseSqlServer(@"Data Source=(localdb)\MSSqlLocalDB;Initial Catalog=DBLocadoraEF");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LocadoraDbContext).Assembly);
            //modelBuilder.ApplyConfiguration(new ParceiroConfiguration());
            //modelBuilder.ApplyConfiguration(new CupomConfiguration());
            //modelBuilder.ApplyConfiguration(new VeiculoConfiguration());
            //modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            //modelBuilder.ApplyConfiguration(new CondutorConfiguration());
        }

        public DbSet<Parceiro> Parceiros { set; get; }
        public DbSet<Cupom> Cupons { set; get; }
        public DbSet<Condutor> Condutores { set; get; }
        public DbSet<Cliente> Clientes { set; get; }
        public DbSet<Funcionario> Funcionarios { set; get; }


    }
}
