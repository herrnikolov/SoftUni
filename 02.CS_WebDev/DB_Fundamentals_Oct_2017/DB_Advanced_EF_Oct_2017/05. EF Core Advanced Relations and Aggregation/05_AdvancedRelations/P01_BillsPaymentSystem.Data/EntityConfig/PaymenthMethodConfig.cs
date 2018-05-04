﻿namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentSystem.Data.Models;

    public class PaymenthMethodConfig : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasIndex(e => new {e.UserId, e.BankAccountId, e.CreditCardId})
                .IsUnique();

            builder.HasOne(e => e.User)
                .WithMany(u => u.PaymentMethods)
                .HasForeignKey(e => e.UserId);

            builder.HasOne(e => e.BankAccount)
                .WithOne(ba => ba.PaymentMethod)
                .HasForeignKey<PaymentMethod>(e => e.BankAccountId);

            builder.HasOne(e => e.CreditCard)
                .WithOne(cc => cc.PaymentMethod)
                .HasForeignKey<PaymentMethod>(e => e.CreditCardId);
        }
    }
}
