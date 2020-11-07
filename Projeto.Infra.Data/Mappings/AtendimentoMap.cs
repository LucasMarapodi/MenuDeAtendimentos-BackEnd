using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class AtendimentoMap : IEntityTypeConfiguration<Atendimento>
    {
        public void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            builder.ToTable("Atendimento");

            builder.HasKey(a => a.IdAtendimento);

            builder.Property(a => a.IdAtendimento).HasColumnName("IdAtendimento").IsRequired();

            builder.Property(a => a.Observacoes).HasColumnName("Observacoes").HasMaxLength(300);

            builder.Property(a => a.Local).HasColumnName("Local").HasMaxLength(150).IsRequired();

            builder.Property(a => a.DataAtendimento).HasColumnName("DataAtendimento").IsRequired();

            builder.HasOne(a => a.Medico).WithMany(m => m.Atendimentos).HasForeignKey(a => a.IdMedico);

            builder.HasOne(a => a.Paciente).WithMany(p => p.Atendimentos).HasForeignKey(a => a.IdPaciente);
        }
    }
}
