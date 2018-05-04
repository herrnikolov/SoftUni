using System;
using System.IO;
using FastFood.Data;
using System.Linq;
using Newtonsoft.Json;

namespace FastFood.DataProcessor
{
	public class Serializer
	{
		public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
		{
		    var employee = context.Employees
		        .Where(e => e.Name == employeeName && e.Orders.Any(o => o.Type.ToString() == orderType))
		        .Select(e => new
		        {
		            Name = e.Name,
		            Orders = e.Orders
		                .Where(o => o.Type.ToString() == orderType)
		                .Select(o => new
		                {
		                    Customer = o.Customer,
		                    Items = o.OrderItems
		                        .Select(oa => new
		                        {
		                            Name = oa.Item.Name,
		                            Price = oa.Item.Price,
		                            Quantity = oa.Quantity
		                        })
		                        .ToArray(),
		                    TotalPrice = o.OrderItems.Sum(oa => oa.Quantity * oa.Item.Price)
		                })
		                .OrderByDescending(o => o.TotalPrice)
		                .ThenByDescending(o => o.Items.Count())
		                .ToArray(),
		            TotalMade = e.Orders.Sum(o => o.OrderItems.Sum(oa => oa.Quantity * oa.Item.Price))
		        })
		        .First();

		    var result = JsonConvert.SerializeObject(employee, Formatting.Indented);

		    return result;
        }

		public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
		{
			throw new NotImplementedException();
		}
	}
}