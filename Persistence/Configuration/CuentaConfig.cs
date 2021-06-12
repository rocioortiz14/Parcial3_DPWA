using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace Persistence.Configuration
{
    public class CuentaConfig : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.ToTable("Cuentas");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.NombreBanco)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(p => p.NombreCliente)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(p => p.FechaApertura)
                .HasMaxLength(30)
                   .IsRequired();
            builder.Property(p => p.NumeroCuenta)
                .HasMaxLength(15)
                   .IsRequired();
            builder.Property(p => p.TipoCuenta)
                .HasMaxLength(10)
               .IsRequired();
            builder.Property(p => p.Retiros)
                .HasMaxLength(10)
               .IsRequired();
            builder.Property(p => p.Depositos)
               .HasMaxLength(10)
               .IsRequired();
            builder.Property(p => p.Saldo)
               .HasMaxLength(10)
               .IsRequired();
            builder.Property(p => p.CreatedBy)
               .HasMaxLength(30);
            builder.Property(p => p.LastModifiedBy)
              .HasMaxLength(30);
        }
    }
}
