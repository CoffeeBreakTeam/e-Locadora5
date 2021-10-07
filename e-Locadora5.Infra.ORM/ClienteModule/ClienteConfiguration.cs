﻿using e_Locadora5.Dominio.ClientesModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Locadora5.Infra.ORM.ClienteModule
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Clientes>
    {
        public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            builder.ToTable("TBClientes");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).HasColumnType("VARCHAR(60)");
            builder.Property(p => p.Endereco).HasColumnType("VARCHAR(110)");
            builder.Property(p => p.Telefone).HasColumnType("VARCHAR(30)");
            builder.Property(p => p.CPF).HasColumnType("VARCHAR(30)");
            builder.Property(p => p.CNPJ).HasColumnType("VARCHAR(30)");
            builder.Property(p => p.RG).HasColumnType("VARCHAR(30)");
            builder.Property(p => p.Email).HasColumnType("VARCHAR(50)");
        }
    }
}
