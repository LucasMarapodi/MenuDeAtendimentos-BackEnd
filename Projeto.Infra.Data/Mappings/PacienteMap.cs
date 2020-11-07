using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class PacienteMap : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Paciente");

            builder.HasKey(p => p.IdPaciente);

            builder.Property(p => p.IdPaciente).HasColumnName("IdPaciente").IsRequired();

            builder.Property(p => p.DataNascimento).HasColumnName("DataNascimento").IsRequired();

            builder.Property(p => p.Email).HasColumnName("Email").HasMaxLength(150).IsRequired();

            builder.Property(p => p.Telefone).HasColumnName("Telefone").HasMaxLength(30).IsRequired();

            builder.Property(p => p.Cpf).HasColumnName("Cpf").HasMaxLength(11).IsRequired();

            builder.HasMany(p => p.Atendimentos).WithOne(a => a.Paciente).HasForeignKey(p => p.IdAtendimento);
        }
    }
}
