using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Import;
using FastFood.Models;
using FastFood.Models.Enums;
using Newtonsoft.Json;

namespace FastFood.DataProcessor
{
	public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportEmployees(FastFoodDbContext context, string jsonString)
		{
		    var sb = new StringBuilder();

		    var deserializedEmployeeDto = JsonConvert.DeserializeObject<EmployeeDto[]>(jsonString);

		    var validEmployees = new List<Employee>();
            var validPositions = new List<Position>();

		    foreach (var employeeDto in deserializedEmployeeDto)
		    {
		        if (!IsValid(employeeDto))
		        {
		            sb.AppendLine(FailureMessage);
		            continue;
		        }

		        var validPosition = validPositions.FirstOrDefault(p => p.Name == employeeDto.Position);

		        if (validPosition == null)
		        {
		            validPosition = new Position()
		            {
		                Name = employeeDto.Position
		            };

		            validPositions.Add(validPosition);
		        }

		        var employee = new Employee
		        {
		            Age = employeeDto.Age,
		            Position = validPosition,
		            Name = employeeDto.Name
		        };

                validEmployees.Add(employee);

		        sb.AppendLine(string.Format(SuccessMessage, employee.Name));
		    }

            context.Positions.AddRange(validPositions);

            context.Employees.AddRange(validEmployees);

		    context.SaveChanges();

		    var result = sb.ToString();
		    return result;
		}

		public static string ImportItems(FastFoodDbContext context, string jsonString)
		{
            var sb = new StringBuilder();

		    var deserializedItemsDro = JsonConvert.DeserializeObject<ItemDto[]>(jsonString);
            
		    var validItems = new List<Item>();
		    var validCategories = new List<Category>();

		    foreach (var dItem in deserializedItemsDro)
		    {
		        if (!IsValid(dItem))
		        {
		            sb.AppendLine(FailureMessage);
		            continue;
		        }

		        var itemAlreadyExists = validItems.Any(i => i.Name == dItem.Name) ||
		                                context.Items.Any(i => i.Name == dItem.Name);

		        if (itemAlreadyExists)
		        {
		            sb.AppendLine(FailureMessage);
                    continue;
		        }

		        var validCategory = validCategories.FirstOrDefault(c => c.Name == dItem.Category);

		        if (validCategory == null)
		        {
		            validCategory = new Category()
		            {
		                Name = dItem.Category
		            };

                    validCategories.Add(validCategory);
		        }

                var item = new Item()
                {
                    Name = dItem.Name,
                    Price = dItem.Price,
                    Category = validCategory
                };

		        validItems.Add(item);

		        sb.AppendLine(string.Format(SuccessMessage, dItem.Name));
		    }
            context.Categories.AddRange(validCategories);
            context.Items.AddRange(validItems);
		    context.SaveChanges();

            var result = sb.ToString();
		    return result;
		}

		public static string ImportOrders(FastFoodDbContext context, string xmlString)
		{
            var result = new List<string>();

            XDocument xDoc = XDocument.Parse(xmlString);

            var elements = xDoc.Root.Elements();

            foreach (var o in elements)
            {
                var customer = o.Element("Customer")?.Value;
                var employeeName = o.Element("Employee")?.Value;
                var timeAsString = o.Element("DateTime")?.Value;
                var typeAsString = o.Element("Type")?.Value;

                if (customer == null || timeAsString == null || typeAsString == null || employeeName == null)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                var employee = context.Employees.SingleOrDefault(e => e.Name == employeeName);

                if (employee == null)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                var time = DateTime.ParseExact(timeAsString, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                object typeObj;
                var isTypeValid = Enum.TryParse(typeof(OrderType), typeAsString, out typeObj);

                if (!isTypeValid)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                var type = (OrderType)typeObj;

                bool areItemsValid = true;
                var items = new List<ItemDto>();

                foreach (var i in o.Element("Items").Elements())
                {
                    string name = i.Element("Name")?.Value;
                    string quantityAsString = i.Element("Quantity")?.Value;

                    if (quantityAsString == null || name == null)
                    {
                        result.Add(FailureMessage);
                        areItemsValid = false;
                    }

                    int quantity = int.Parse(quantityAsString);

                    var item = context.Items.SingleOrDefault(it => it.Name == name);

                    if (item == null || quantity <= 0)
                    {
                        result.Add(FailureMessage);
                        areItemsValid = false;
                    }

                    items.Add(new ItemDto { Name = name, Quantity = quantity });
                }

                if (!areItemsValid)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                var order = new Order { Customer = customer, DateTime = time, Employee = employee, Type = type };
                context.Orders.Add(order);

                foreach (var itemDto in items)
                {
                    var item = context.Items.SingleOrDefault(i => i.Name == itemDto.Name);
                    context.OrderItems.Add(new OrderItem { Item = item, Order = order, Quantity = itemDto.Quantity });
                }

                context.SaveChanges();

                result.Add($"Order for {customer} on {time.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)} added");
            }

            return String.Join(Environment.NewLine, result);

            //throw new NotImplementedException();
        }

	    private static bool IsValid(object obj)
	    {
	        var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
	        var validationResults = new List<ValidationResult>();

	        var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
	        return isValid;
	    }
    }
}