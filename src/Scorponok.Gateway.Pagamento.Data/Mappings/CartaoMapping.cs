using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scorponok.Gateway.Pagamento.Domain.Models.FormaPagamentos;

namespace Scorponok.Gateway.Pagamento.Cross.Cutting.Data.Mappings
{
    public class CartaoMapping : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.ToTable("CARTAO");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Bandeira)
                .HasColumnName("Bandeira")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Numero)
                .HasColumnName("Numero")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Expiracao)
                .HasColumnName("Expiracao")
                .HasMaxLength(6)
                .IsRequired();

            builder.Property(x => x.Portador)
                .HasColumnName("Portador")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Cvv)
                .HasColumnName("Cvv")
                .HasMaxLength(5)
                .IsRequired();

            builder.HasMany(x => x.TransactionsInternal)
                .WithOne(x => x.Cartao)
                .IsRequired();


            builder.Ignore(x => x.Transactions);

        }
    }
}
