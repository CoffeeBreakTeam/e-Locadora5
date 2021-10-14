using e_Locadora5.Dominio.TaxasServicosModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.TaxasServicosModule
{
    public class TaxasServicosConfiguration : IEntityTypeConfiguration<TaxasServicos>
    {
        public void Configure(EntityTypeBuilder<TaxasServicos> builder)
        {
            builder.ToTable("TBTaxasServicos");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.TaxaDiaria).HasColumnType("DECIMAL(18,2)");
            builder.Property(p => p.TaxaFixa).HasColumnType("DECIMAL(18,2)");
            builder.Property(p => p.Descricao).HasColumnType("VARCHAR(100)");

            //relacionamento
            builder.HasMany(p => p.locacoes);
          

        }
    }
}
