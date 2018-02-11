using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes;
using System;

namespace Scorponok.Gateway.Pagamento.Cross.Cutting.Data.Mappings
{
    public class TransacaoMapping : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> mb)
        {
            mb.ToTable("TRANSACAO");

            mb.HasKey(x => x.Id);

            mb.Property(x => x.DataCriacao)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            mb.Property(x => x.DataAtualizacao);

            mb.HasOne(x => x.Cartao)
                .WithMany(x => x.TransactionsInternal)
                .IsRequired();
        }
    }
}
