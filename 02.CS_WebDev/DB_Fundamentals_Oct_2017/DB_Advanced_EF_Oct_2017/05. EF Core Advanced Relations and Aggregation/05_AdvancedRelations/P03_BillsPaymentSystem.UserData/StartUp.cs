namespace P03_BillsPaymentSystem.UserData
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    using P01_BillsPaymentSystem.Data;
    using P01_BillsPaymentSystem.Data.Models;

    class StartUp
    {
        static void Main(string[] args)
        {
            var userId = int.Parse(Console.ReadLine());

            using (var db = new BillsPaymentSystemContext())
            {
                var user = db.Users
                    .Where(u => u.UserId == userId)
                    .Select(u => new
                    {
                        Name = $"{u.FirstName} {u.LastName}",
                        CreditCards = u.PaymentMethods
                            .Where(pm => pm.Type == PaymentMethodType.CreditCard)
                            .Select(pm => pm.CreditCard).ToList(),
                        BankAccounts = u.PaymentMethods
                            .Where(pm => pm.Type == PaymentMethodType.BankAccount)
                            .Select(pm => pm.BankAccount).ToList()
                    }).FirstOrDefault();

                Console.WriteLine($"User: {user.Name}");

                var bankAccounts = user.BankAccounts;
                if (bankAccounts.Any())
                {
                    Console.WriteLine("Bank Accounts:");
                    foreach (var ba in bankAccounts)
                    {
                        Console.WriteLine
                            ($@"-- ID: {ba.BankAccountId}
--- Balance: {ba.Balance:F2}
--- Bank: {ba.BankName}
--- SWIFT: {ba.SwiftCode}
                            ");
                    }
                }

                var creditCards = user.CreditCards;
                if (creditCards.Any())
                {
                    Console.WriteLine("Credit Cards:");
                    foreach (var cc in creditCards)
                    {
                        Console.WriteLine
                        ($@"-- ID: {cc.CreditCardId}
--- Limit: {cc.Limit:F2}
--- Money Owed: {cc.MoneyOwed:F2}
--- Limit Left: {cc.LimitLeft:F2}
--- Expiration Date: {cc.ExpirationDate.ToString("yyyy/MM", CultureInfo.InvariantCulture)}
                            ");
                    }
                }
            }
        }
    }
}