using e_Locadora5.Dominio;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.Dominio.VeiculosModule;
using e_Locadora5.Infra.ORM.ClienteModule;
using e_Locadora5.Infra.ORM.CondutorModule;
using e_Locadora5.Infra.ORM.CupomModule;
using e_Locadora5.Infra.ORM.FuncionarioModule;
using e_Locadora5.Infra.ORM.VeiculoModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.ParceiroModule
{
    public class LocadoraDbContext : DbContext
    {
        private static readonly ILoggerFactory ConsoleLoggerFactory
              = LoggerFactory.Create(builder =>
              {
                  builder
                      .AddFilter((category, level) =>
                          category == DbLoggerCategory.Database.Command.Name
                          && level == LogLevel.Information)
                      .AddDebug();
              });
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder
                .UseLoggerFactory(ConsoleLoggerFactory)
                //.UseLazyLoadingProxies()                
                //.UseSqlServer(@"Data Source=(localdb)\MSSqlLocalDB;Initial Catalog=DBLocadoraEF;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;TrustServerCertificate=False");
                .UseSqlServer(@"Data Source=(localdb)\MSSqlLocalDB;Initial Catalog=DBLocadoraEF");
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex,$"Erro ao conectar ao banco");
                throw;
            }
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LocadoraDbContext).Assembly);

        }

        public DbSet<Parceiro> Parceiros { set; get; }
        public DbSet<Cupom> Cupons { set; get; }
        public DbSet<Condutor> Condutores { set; get; }
        public DbSet<Cliente> Clientes { set; get; }
        public DbSet<Funcionario> Funcionarios { set; get; }
        public DbSet<Locacao> locacoes { set; get; }
        public DbSet<GrupoVeiculo> GrupoVeiculos { set; get; }
        public DbSet<TaxasServicos> TaxasServicos { set; get; }
        public DbSet<Veiculo> Veiculos { set; get; }

    }
}
