namespace P04_BillsPaymentSystem.PayBills
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Globalization;

    using Microsoft.EntityFrameworkCore;

    using P01_BillsPaymentSystem.Data;
    using P01_BillsPaymentSystem.Data.Models;

    class StartUp
    {
        public static void Main()
        {
            using (var db = new BillsPaymentSystemContext())
            {
                var userId = int.Parse(Console.ReadLine());
                var user = db.Users.Find(userId);

                var amount = decimal.Parse(Console.ReadLine());

                try
                {
                    PayBills(userId, amount, db);
                    Console.WriteLine("Bills have been successfully paid.");
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void PayBills(int userId, decimal amount, BillsPaymentSystemContext context)
        {
            var user = context.Users.Find(userId);

            if (user == null)
            {
                Console.WriteLine($"User with id {userId} not found!");
                return;
            }

            decimal userMoney = 0m;

            var bankAccounts = context
                .BankAccounts.Join(context.PaymentMethods,
                    (ba => ba.BankAccountId),
                    (p => p.BankAccountId),
                    (ba, p) => new
                    {
                        UserId = p.UserId,
                        BankAccountId = ba.BankAccountId,
                        Balance = ba.Balance
                    })
                .Where(ba => ba.UserId == userId)
                .ToList();


            var creditCards = context
                .CreditCards.Join(context.PaymentMethods,
                    (c => c.CreditCardId),
                    (p => p.CreditCardId),
                    (c, p) => new
                    {
                        UserId = p.UserId,
                        CreditCardId = c.CreditCardId,
                        LimitLeft = c.LimitLeft
                    })
                .Where(c => c.UserId == userId)
                .ToList();

            userMoney += bankAccounts.Sum(b => b.Balance);
            userMoney += creditCards.Sum(c => c.LimitLeft);

            if (userMoney < amount)
            {
                throw new InvalidOperationException("Insufficient funds!");
            }

            bool isBillsPayed = false;
            foreach (var bankAccount in bankAccounts.OrderBy(b => b.BankAccountId))
            {
                var currentAccount = context.BankAccounts.Find(bankAccount.BankAccountId);

                if (amount <= currentAccount.Balance)
                {
                    currentAccount.Withdraw(amount);
                    isBillsPayed = true;
                }
                else
                {
                    amount -= currentAccount.Balance;
                    currentAccount.Withdraw(currentAccount.Balance);
                }

                if (isBillsPayed)
                {
                    context.SaveChanges();
                    return;
                }
            }

            foreach (var creditCard in creditCards.OrderBy(c => c.CreditCardId))
            {
                var currentCreditCard = context.CreditCards.Find(creditCard.CreditCardId);

                if (amount <= currentCreditCard.LimitLeft)
                {
                    currentCreditCard.Withdraw(amount);
                    isBillsPayed = true;
                }
                else
                {
                    amount -= currentCreditCard.LimitLeft;
                    currentCreditCard.Withdraw(currentCreditCard.LimitLeft);
                }

                if (isBillsPayed)
                {
                    context.SaveChanges();
                    return;
                }
            }
        }
    }
}
