using System;
using System.Collections.Generic;
using System.Linq;

public class Andrey_and_Billiard
{
    public static void Main()
    {
        var entitiesAmount = int.Parse(Console.ReadLine());

        var productsPrices = new Dictionary<string, double>();
        GetProductsAndPrices(entitiesAmount, productsPrices);

        var line = Console.ReadLine();
        var customers = new List<Customer>();

        while (!line.Equals("end of clients"))
        {

            var clientData = line
                .Split("- ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var clientName = clientData[0];
            var productName = clientData[1];

            if (productsPrices.ContainsKey(productName))
            {
                var productQuantity = int.Parse(clientData[2]);

                if (customers.Any(c => c.Name == clientName))
                {
                    var customer = customers.First(c => c.Name == clientName);

                    if (!customers.First(c => c.Name == clientName).ShopList.ContainsKey(productName))
                    {
                        customer.ShopList.Add(productName, productQuantity);
                        customer.Bill += productQuantity * productsPrices[productName];
                    }

                    else
                    {
                        customer.ShopList[productName] += productQuantity;

                        customer.Bill += productQuantity * productsPrices[productName];
                    }
                }

                else
                {
                    var currentCustomer = new Customer();

                    currentCustomer.Name = clientName;
                    currentCustomer.ShopList = new Dictionary<string, long>();
                    currentCustomer.ShopList.Add(productName, productQuantity);
                    currentCustomer.Bill += productQuantity * productsPrices[productName];

                    customers.Add(currentCustomer);
                }
            }

            line = Console.ReadLine();
        }

        double totalBill = 0;

        foreach (var customer in customers.OrderBy(x => x.Name))
        {
            Console.WriteLine(customer.Name);

            foreach (var item in customer.ShopList)
            {
                Console.WriteLine($"-- {item.Key} - {item.Value}");
            }

            Console.WriteLine($"Bill: {customer.Bill:F2}");

            totalBill += customer.Bill;
        }

        Console.WriteLine($"Total bill: {totalBill:F2}");
    }

    private static void GetProductsAndPrices(int entitiesAmount, Dictionary<string, double> productsPrices)
    {
        for (int i = 0; i < entitiesAmount; i++)
        {
            var productData = Console.ReadLine()
                .Split('-');

            var productName = productData[0];
            var productPrice = double.Parse(productData[1]);

            if (!productsPrices.ContainsKey(productName))
            {
                productsPrices.Add(productName, productPrice);
            }

            else
            {
                productsPrices[productName] = productPrice;
            }
        }
    }
}

public class Customer
{
    public string Name { get; set; }

    public Dictionary<string, long> ShopList { get; set; }

    public double Bill { get; set; }
}