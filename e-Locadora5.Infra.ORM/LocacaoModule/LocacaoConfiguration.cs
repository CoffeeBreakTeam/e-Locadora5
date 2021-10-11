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
            builder.ToTable("TBLocacao");

            builder.HasKey(p => p.Id);
          
            builder.Property(p => p.dataLocacao).HasColumnType("datetime");
            builder.Property(p => p.dataDevolucao).HasColumnType("datetime");
            builder.Property(p => p.quilometragemDevolucao).HasColumnType("float");
            builder.Property(p => p.plano).HasColumnType("nvarchar(max)");
            builder.Property(p => p.seguroCliente).HasColumnType("float");
            builder.Property(p => p.seguroTerceiro).HasColumnType("float");
            builder.Property(p => p.caucao).HasColumnType("float");          
            builder.Property(p => p.emAberto).HasColumnType("bit");
            builder.Property(p => p.emailEnviado).HasColumnType("bit");
            builder.Property(p => p.MarcadorCombustivel).HasColumnType("int");        
            builder.Property(p => p.valorTotal).HasColumnType("float");
            
            builder.Property(p => p.funcionarioId).HasColumnType("int");
            builder.Property(p => p.clienteId).HasColumnType("int");
            builder.Property(p => p.condutorId).HasColumnType("int");
            builder.Property(p => p.cupomId).HasColumnType("int");
            builder.Property(p => p.veiculoId).HasColumnType("int");
            builder.Property(p => p.grupoVeiculoId).HasColumnType("int");
                  
            //relacionamento
            //builder.HasOne(p => p.plano);
            //builder.HasOne(p => p.grupoVeiculo);
            //builder.HasOne(p => p.funcionario);
            //builder.HasOne(p => p.veiculo);
            //builder.HasOne(p => p.cliente);
            //builder.HasOne(p => p.condutor);

        }
    }
}
