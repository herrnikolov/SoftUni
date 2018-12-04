namespace Chushka.App
{
    using Chushka.Data;
    using Chushka.Models;
    using Microsoft.EntityFrameworkCore;
    using SoftUni.WebServer.Mvc;
    using SoftUni.WebServer.Mvc.Routers;
    using SoftUni.WebServer.Server;
    using System;
    using System.Linq;

    public class Launcher
    {
        // If you have problems with path prefix change it in Chushka.App.Common.Constants class!
        // I'm using services in separated project

        public static void Main()
        {
            InitializeDatabase();

            Seed();

            var server = new WebServer(8000,
                new ControllerRouter(),
                new ResourceRouter());

            MvcEngine.Run(server);
        }

        private static void InitializeDatabase()
        {
            Console.WriteLine("Initializing database...");
            using (var context = new ChushkaDbContext())
            {
                context.Database.Migrate();
            }
            Console.WriteLine("Database is ready to use!");
        }

        private static void Seed()
        {
            Console.WriteLine("Seeding data...");
            using (var context = new ChushkaDbContext())
            {
                if (!context.Roles.Any())
                {
                    context.Roles.Add(new Role() { Name = "User" });
                    context.Roles.Add(new Role() { Name = "Admin" });

                    context.SaveChanges();
                }

                if (!context.ProductTypes.Any())
                {
                    {
                        context.ProductTypes.Add(new ProductType() { Name = "Food" });
                        context.ProductTypes.Add(new ProductType() { Name = "Domestic" });
                        context.ProductTypes.Add(new ProductType() { Name = "Health" });
                        context.ProductTypes.Add(new ProductType() { Name = "Cosmetic" });
                        context.ProductTypes.Add(new ProductType() { Name = "Other" });

                        context.SaveChanges();
                    }
                }
            }
            Console.WriteLine("Data seeded!");
        }
    }
}
