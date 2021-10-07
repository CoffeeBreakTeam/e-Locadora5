using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.ParceirosModule;
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
            modelBuilder.ApplyConfiguration(new ParceiroConfiguration());
            modelBuilder.ApplyConfiguration(new FuncionarioConfiguration());
            modelBuilder.ApplyConfiguration(new VeiculoConfiguration());
        }

        public DbSet<Parceiro> Parceiros { set; get; }
        public DbSet<Cupons> Cupons { set; get; }
    }
}
