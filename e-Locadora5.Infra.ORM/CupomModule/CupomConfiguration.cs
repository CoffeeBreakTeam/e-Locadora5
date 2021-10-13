using e_Locadora5.Dominio.CupomModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.CupomModule
{
    public class CupomConfiguration : IEntityTypeConfiguration<Cupom>
    {
        public void Configure(EntityTypeBuilder<Cupom> builder)
        {
            builder.ToTable("TBCupom");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).HasColumnType("VARCHAR(50)");
            builder.Property(p => p.ValorPercentual).HasColumnType("INT");
            builder.Property(p => p.ValorFixo).HasColumnType("DECIMAL(18,2)");
            builder.Property(p => p.DataValidade).HasColumnType("DATE");
            builder.Property(p => p.ParceiroId).HasColumnType("INT");
            builder.Property(p => p.ValorMinimo).HasColumnType("DECIMAL(18,2)");

            //relacionamento
            builder.HasOne(p => p.Parceiro).WithMany(p => p.Cupons).HasForeignKey(p => p.ParceiroId);

        }
    }
}
