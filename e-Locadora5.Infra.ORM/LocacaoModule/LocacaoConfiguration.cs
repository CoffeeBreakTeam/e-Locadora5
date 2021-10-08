using e_Locadora5.Dominio.LocacaoModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.LocacaoModule
{
    public class LocacaoConfiguration : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("Locacao");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.funcionario).HasColumnType("int");
            builder.Property(p => p.dataLocacao).HasColumnType("datetime2");
            builder.Property(p => p.dataDevolucao).HasColumnType("datetime2");
            builder.Property(p => p.quilometragemDevolucao).HasColumnType("float");
            builder.Property(p => p.plano).HasColumnType("nvarchar(max)");
            builder.Property(p => p.seguroCliente).HasColumnType("float");
            builder.Property(p => p.seguroTerceiro).HasColumnType("float");
            builder.Property(p => p.caucao).HasColumnType("float");
            builder.Property(p => p.grupoVeiculo).HasColumnType("int");
            builder.Property(p => p.veiculo).HasColumnType("int");
            builder.Property(p => p.cliente).HasColumnType("int");
            builder.Property(p => p.condutor).HasColumnType("int");
            builder.Property(p => p.emAberto).HasColumnType("bit");
            builder.Property(p => p.emailEnviado).HasColumnType("bit");
            builder.Property(p => p.MarcadorCombustivel).HasColumnType("int");
            builder.Property(p => p.valorTotal).HasColumnType("float");
        }
    }
}
