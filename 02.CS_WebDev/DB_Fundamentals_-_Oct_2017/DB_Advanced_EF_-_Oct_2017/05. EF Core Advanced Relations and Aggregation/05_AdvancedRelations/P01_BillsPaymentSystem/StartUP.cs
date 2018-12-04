namespace P01_BillsPaymentSystem
{
    using System;
    using Microsoft.EntityFrameworkCore;

    using P01_BillsPaymentSystem.Data;
    using P01_BillsPaymentSystem.Data.Models;

    class StartUp
    {
        static void Main(string[] args)
        {
            using (var db = new BillsPaymentSystemContext())
            {
                db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();
                db.Database.Migrate();
                Seed(db);
            }
        }

        private static void Seed(BillsPaymentSystemContext db)
        {
            using (db)
            {

                var user = new User()
                {
                    FirstName = "Pesho",
                    LastName = "Stamatov",
                    Email = "pesho@abv.bg",
                    Password = "azsympesho"
                };

                var creditCards = new CreditCard[]
                {
                    new CreditCard()
                    {
                        ExpirationDate = DateTime.ParseExact("20.05.2020", "dd.MM.yyyy", null),
                        Limit = 1000m,
                        MoneyOwed = 5m
                    },
                    new CreditCard()
                    {
                        ExpirationDate = DateTime.ParseExact("20.05.2020", "dd.MM.yyyy", null),
                        Limit = 400m,
                        MoneyOwed = 200m
                    }
                };

                var bankAccount = new BankAccount()
                {
                    Balance = 1500m,
                    BankName = "Swiss Bank",
                    SwiftCode = "SWSSBANK"
                };

                var paymentMethods = new PaymentMethod[]
                {
                    new PaymentMethod()
                    {
                        User = user,
                        CreditCard = creditCards[0],
                        Type = PaymentMethodType.CreditCard
                    },
                    new PaymentMethod()
                    {
                        User = user,
                        CreditCard = creditCards[1],
                        Type = PaymentMethodType.CreditCard
                    },
                    new PaymentMethod()
                    {
                        User = user,
                        BankAccount = bankAccount,
                        Type = PaymentMethodType.BankAccount
                    },
                };

                db.Users.Add(user);
                db.CreditCards.AddRange(creditCards);
                db.BankAccounts.Add(bankAccount);
                db.PaymentMethods.AddRange(paymentMethods);

                db.SaveChanges();
            }
        }
    }
}
