using e_Locadora5.Dominio.CondutoresModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.CondutorModule
{
    class CondutorConfiguration : IEntityTypeConfiguration<Condutor>
    {
        public void Configure(EntityTypeBuilder<Condutor> builder)
        {
            builder.ToTable("TBCondutor");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).HasColumnType("VARCHAR(60)");
            builder.Property(p => p.Endereco).HasColumnType("VARCHAR(110)");
            builder.Property(p => p.Telefone).HasColumnType("VARCHAR(20)");
            builder.Property(p => p.Cpf).HasColumnType("VARCHAR(30)");
            builder.Property(p => p.NumeroCNH).HasColumnType("VARCHAR(30)");
            builder.Property(p => p.ClienteId).HasColumnType("INT");
            builder.Property(p => p.Rg).HasColumnType("VARCHAR(30)");
            builder.Property(p => p.ValidadeCNH).HasColumnType("DATE");

            builder.HasOne(c => c.Cliente);
        }
    }
}
