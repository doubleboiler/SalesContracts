namespace SellContracts.Migrations
{
    using SellContracts.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SellContracts.Models.SaleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SellContracts.Models.SaleContext context)
        {
            var sale1 = new Sale { Name = "Продажа1", AgentId = 1, ClientId = 1 };
            var sale2 = new Sale { Name = "Продажа2", AgentId = 1, ClientId = 2 };
            var Agent1 = new Agent { Name = "Сотрудник1" };
            var Client1 = new Client { Name = "Контрагент1", Company = "Компания1", CityId = 1 };
            var Client2 = new Client { Name = "Контрагент2", Company = "Компания2", CityId = 1 };
            var City1 = new City { Name = "СПб" };

            context.Sales.Add(sale1);
            context.Sales.Add(sale2);
            context.Agents.Add(Agent1);
            context.Clients.Add(Client1);
            context.Clients.Add(Client2);
            context.Cities.Add(City1);

            context.SaveChanges();
        }
    }
}
