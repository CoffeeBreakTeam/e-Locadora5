using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Infra.ORM.CupomModule;
using e_Locadora5.Infra.ORM.ClienteModule;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.ApplyConfiguration(new CupomConfiguration());
            modelBuilder.ApplyConfiguration(new ParceiroConfiguration())
                .ApplyConfiguration(new ClienteConfiguration());
         
        }
        public DbSet<Parceiro> Parceiros { set; get; }
        public DbSet<Cupons> Cupons { set; get; }
        public DbSet<Clientes> Clientes { set; get; }
    }
}
