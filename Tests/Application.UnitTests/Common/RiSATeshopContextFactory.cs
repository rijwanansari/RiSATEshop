using System;
using Microsoft.EntityFrameworkCore;
using RiSAT.Eshop.Domain.Entities;
using RiSAT.Eshop.Persistence;

namespace RiSAT.Eshop.Application.UnitTests.Common
{
    public class RiSATeshopContextFactory
    {
        public static RiSATeshopDbContext Create()
        {
            var options = new DbContextOptionsBuilder<RiSATeshopDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new RiSATeshopDbContext(options);

            context.Database.EnsureCreated();

            context.Customers.AddRange(new[] {
                new Customer { CustomerId = "ADAM", ContactName = "Adam Cogan" },
                new Customer { CustomerId = "JASON", ContactName = "Jason Taylor" },
                new Customer { CustomerId = "BREND", ContactName = "Brendan Richards" },
            });

            context.Orders.Add(new Order
            {
                CustomerId = "BREND"
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(RiSATeshopDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}