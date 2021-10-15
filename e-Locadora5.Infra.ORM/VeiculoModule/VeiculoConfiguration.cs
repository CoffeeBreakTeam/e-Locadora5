using e_Locadora5.Dominio.VeiculosModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.VeiculoModule
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("TBVeiculo");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Placa).HasColumnType("VARCHAR(50)");
            builder.Property(p => p.Modelo).HasColumnType("VARCHAR(50)");
            builder.Property(p => p.Fabricante).HasColumnType("VARCHAR(50)");
            builder.Property(p => p.Quilometragem).HasColumnType("NUMERIC");
            builder.Property(p => p.QtdLitrosTanque).HasColumnType("INT");
            builder.Property(p => p.QtdPortas).HasColumnType("INT");
            builder.Property(p => p.NumeroChassi).HasColumnType("VARCHAR(50)");
            builder.Property(p => p.Cor).HasColumnType("VARCHAR(50)");
            builder.Property(p => p.CapacidadeOcupantes).HasColumnType("INT");
            builder.Property(p => p.AnoFabricacao).HasColumnType("INT");
            builder.Property(p => p.TamanhoPortaMalas).HasColumnType("VARCHAR(50)");
            builder.Property(p => p.Combustivel).HasColumnType("VARCHAR(50)");
            builder.Property(p => p.Imagem).HasColumnType("IMAGE");
          
            builder.HasOne(l => l.GrupoVeiculo)
               .WithMany()
               .HasForeignKey(l => l.GrupoVeiculoId)
               .OnDelete(DeleteBehavior.Restrict).HasConstraintName("FK_TBVeiculo_TBGrupoVeiculo");

        }
    }
}
