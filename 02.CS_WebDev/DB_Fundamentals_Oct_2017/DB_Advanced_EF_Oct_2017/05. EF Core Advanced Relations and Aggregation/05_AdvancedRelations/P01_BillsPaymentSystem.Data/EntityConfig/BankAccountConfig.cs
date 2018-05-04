namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentSystem.Data.Models;

    public class BankAccountConfig : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(e => e.BankAccountId);

            builder.Property(e => e.BankName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.SwiftCode)
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(50);

            builder.Ignore(e => e.PaymentMethodId);

        }
    }
}
