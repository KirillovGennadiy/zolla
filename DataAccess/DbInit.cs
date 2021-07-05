using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.Models;

namespace Test.DataAccess
{
    public static class DbInit
    {
        // Init data
        public static void Initialize(TestDbContext context, int recordsCount = 15)
        {
            if (!context.Clients.Any())
            {
                List<Client> clients = new List<Client>();
                Random rnd = new Random();

                for (int i = 0; i < recordsCount; i++)
                {
                    List<Order> orders = new List<Order>();
                    for (int j = 0; j < recordsCount; j++)
                    {
                        orders.Add(new Order
                        {
                            Name = $"Test order c{i}{j}-{rnd.Next(1500)}",
                            Price = Math.Round(rnd.Next(25000) + rnd.NextDouble(), 2),
                            CreateDate = new DateTime(rnd.Next(2019, 2021), rnd.Next(1, 12), rnd.Next(1, 30))
                        });
                    }

                    clients.Add(new Client
                    {
                        LastName = $"LastName {i}",
                        FirstName = $"FirstName {i}",
                        Patronymic = $"Patronymic {i}",
                        BirthDate = new DateTime(rnd.Next(1975, 2004), rnd.Next(1, 12), rnd.Next(1, 30)),
                        Orders = orders
                    });
                }

                context.Clients.AddRange(clients);
                context.SaveChanges();
            }
        }
    }
}