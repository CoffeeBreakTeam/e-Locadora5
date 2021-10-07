using e_Locadora5.Dominio.FuncionarioModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.FuncionarioModule
{
    public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {

        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("TBFuncionario");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(50)");
            builder.Property(p => p.NumeroCpf).HasColumnType("VARCHAR(50)");
            builder.Property(p => p.Usuario).HasColumnType("VARCHAR(50)");
            builder.Property(p => p.DataAdmissao).HasColumnType("DATE");
            builder.Property(p => p.Salario).HasColumnType("NUMERIC");

        }
    }
}

