using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes;

namespace Scorponok.Gateway.Pagamento.Data.Mappings
{
    public class TransacaoMapping : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> mb)
        {
            mb.ToTable("TRANSACAO");

            mb.HasKey(x => x.Id);

            mb.HasOne(x => x.Cartao)
                .WithMany(x => x.TransactionsInternal)
                .IsRequired();
        }
    }
}
