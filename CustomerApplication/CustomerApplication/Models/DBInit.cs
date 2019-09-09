using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomerApplication.Models
{
    public class DBInit : DropCreateDatabaseAlways<DB>
    {
        protected override void Seed(DB context)
        {
            var newCustomer = new Customer
            {
                FullName = "Ole Hansen"
            };

            var newOrder = new Order
            {
                Date = "23.05.2017"
            };

            var newProduct1 = new Product
            {
                Price = 2.34,
                ProductName = "Mutter 3mm"
            };
            var newProduct2 = new Product
            {
                Price = 3.34,
                ProductName = "Mutter 4mm"
            };

            var newOrderLine1 = new OrderLine
            {
                Product = newProduct1,
                Quantity = 100
            };

            var newOrderLine2 = new OrderLine
            {
                Product = newProduct2,
                Quantity = 50
            };

            // add ordelines to the new order
            // There is no existing list of orderlines, so it must be created
            var newOrderline = new List<OrderLine>();
            newOrderline.Add(newOrderLine1);
            newOrderline.Add(newOrderLine2);

            newOrder.OrderLines = newOrderline;

            // There is no existing list of orders in the customer, so it must be created
            var newOrders = new List<Order>();
            newOrders.Add(newOrder);
            newCustomer.Order = newOrders;

            // Add the customer with all the datas to the database
            context.Customer.Add(newCustomer);
            base.Seed(context);
        }
    }
}