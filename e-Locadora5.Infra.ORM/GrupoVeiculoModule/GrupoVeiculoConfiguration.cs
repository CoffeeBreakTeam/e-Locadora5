using e_Locadora5.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.GrupoVeiculoModule
{
    public class GrupoVeiculoConfiguration : IEntityTypeConfiguration<GrupoVeiculo>
    {
        public void Configure(EntityTypeBuilder<GrupoVeiculo> builder)
        {
            builder.ToTable("TBGrupoVeiculo");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.categoria).HasColumnType("VARCHAR(100)");
            builder.Property(p => p.planoDiarioValorKm).HasColumnType("float");
            builder.Property(p => p.planoDiarioValorDiario).HasColumnType("float");
            builder.Property(p => p.planoKmControladoValorKm).HasColumnType("float");
            builder.Property(p => p.planoKmControladoQuantidadeKm).HasColumnType("float");
            builder.Property(p => p.planoKmControladoValorDiario).HasColumnType("float");
            builder.Property(p => p.planoKmLivreValorDiario).HasColumnType("float");
        }
    }
}
