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
            builder.Property(p => p.quilometragemDevolucao).HasColumnType("decimal(18,2)");
            builder.Property(p => p.plano).HasColumnType("varchar(50)");
            builder.Property(p => p.seguroCliente).HasColumnType("decimal(18,2)");
            builder.Property(p => p.seguroTerceiro).HasColumnType("decimal(18,2)");
            builder.Property(p => p.caucao).HasColumnType("decimal(18,2)");          
            builder.Property(p => p.emAberto).HasColumnType("bit");
            builder.Property(p => p.emailEnviado).HasColumnType("bit");
            builder.Property(p => p.MarcadorCombustivel).HasColumnType("int");        
            builder.Property(p => p.valorTotal).HasColumnType("decimal(18,2)");


            // relacionamento
            builder.HasMany(l => l.TaxasServicos);

            builder.HasOne(l => l.Cupom)
                .WithMany(c => c.Locacoes)     
                .HasForeignKey(c => c.CupomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TBLocacao_TBCupom");

            builder.HasOne(l => l.GrupoVeiculo)
                .WithMany().
                HasForeignKey(l => l.GrupoVeiculoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_TBLocacao_TBGrupoVeiculo");

            builder.HasOne(l => l.Funcionario)
                .WithMany()
                .HasForeignKey(l => l.FuncionarioId)             
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_TBLocacao_TBFuncionario");

            builder.HasOne(l => l.Veiculo)
                .WithMany(x => x.Locacoes)
                .HasForeignKey(p => p.VeiculoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_TBLocacao_TBVeiculo");

            //builder.Ignore(x => x.Cliente);

            builder.HasOne(l => l.Condutor)
                .WithMany()
                .HasForeignKey(l => l.CondutorId)          
                .OnDelete(DeleteBehavior.Restrict).HasConstraintName("FK_TBLocacao_TBCondutor");

            builder.HasOne(l => l.Cliente)
                .WithMany()
                .HasForeignKey(l => l.ClienteId)
                .OnDelete(DeleteBehavior.Restrict).HasConstraintName("FK_TBLocacao_TBCliente");

        }
    }
}
