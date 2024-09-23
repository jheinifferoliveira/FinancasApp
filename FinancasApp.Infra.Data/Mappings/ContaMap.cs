using FinancasApp.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Data.Mappings
{
    public class ContaMap : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("CONTA");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("ID");

            builder.Property(c => c.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Data)
                .HasColumnName("DATA")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(c => c.Valor)
               .HasColumnName("VALOR")
               .HasColumnType("decimal(18,2)")
               .IsRequired();

            builder.Property(c => c.Tipo)
               .HasColumnName("TIPO")
               .IsRequired();

            builder.Property(c => c.UsuarioId)
                .HasColumnName("USUARIO_ID")
                .IsRequired();

            builder.HasOne(c=>c.Usuario)
                .WithMany(u=>u.Contas)
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
