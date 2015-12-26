namespace damacanawebapi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using damacanawebapi.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<damacanawebapi.Models.damacanawebapiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "damacanawebapi.Models.damacanawebapiContext";
        }

        protected override void Seed(damacanawebapi.Models.damacanawebapiContext context)
        {
            context.Products.AddOrUpdate(x => x.Id,
                new Product() { Id = 1, name="Erikli", price=10  },
                new Product() { Id = 2, name="sirma", price=8 },
                new Product() { Id = 3,  name="pinar", price=5}
                );

            
        }
    }
}
