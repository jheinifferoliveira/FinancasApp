﻿using FinancasApp.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Data.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("CATEGORIA");
            builder.HasKey(c => c.Id);

            builder.Property(c=>c.Id).HasColumnName("ID");

            builder.Property(c => c.Nome).HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c=>c.UsuarioId)
                .HasColumnName("USUARIO_ID");

            builder.HasOne(c => c.Usuario)
                 .WithMany(u => u.Categorias)
                 .HasForeignKey(c => c.UsuarioId)
                 .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
