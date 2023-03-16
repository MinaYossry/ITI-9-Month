namespace CustomersAndOrders.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CustomersAndOrders.Data.CustomersAndOrdersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "CustomersAndOrders.Data.CustomersAndOrdersContext";
        }

        protected override void Seed(CustomersAndOrders.Data.CustomersAndOrdersContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
