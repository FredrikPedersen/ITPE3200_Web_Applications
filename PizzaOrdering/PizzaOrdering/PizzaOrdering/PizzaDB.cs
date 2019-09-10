using PizzaOrdering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaOrdering
{
    public class PizzaDB
    {
        public bool newOrder(Pizza orderedPizza)
        {
            using (var db = new PizzaContext())
            {
                var order = new Order()
                {
                    quantity = orderedPizza.quantity,
                    pizzaType = orderedPizza.pizzaType,
                    thick = orderedPizza.thick
                };

                OrderCustomer foundCustomer = db.orderCustomers.FirstOrDefault(oc => oc.fullName == orderedPizza.fullName);

                if (foundCustomer == null)
                {
                    var orderCustomer = new OrderCustomer
                    {
                        fullName = orderedPizza.fullName,
                        address = orderedPizza.address,
                        phoneNumber = orderedPizza.phoneNumber
                    };
                    orderCustomer.orders = new List<Order>();
                    orderCustomer.orders.Add(order);

                    try
                    {
                        db.orderCustomers.Add(orderCustomer);
                        db.SaveChanges();
                        return true;
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }
                else
                {
                    try
                    {
                        foundCustomer.orders.Add(order);
                        db.SaveChanges();
                        return true;
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }
            }
        }

        public List<Pizza> listAllOrders()
        {
            var db = new PizzaContext();
            List<OrderCustomer> allCustomers = db.orderCustomers.ToList();
            List<Pizza> allOrders = new List<Pizza>();
            foreach (var customer in allCustomers)
            {
                foreach (var order in customer.orders)
                {
                    var aOrder = new Pizza();
                    aOrder.fullName = customer.fullName;
                    aOrder.address = customer.address;
                    aOrder.phoneNumber = customer.phoneNumber;
                    aOrder.quantity = order.quantity;
                    aOrder.thick = order.thick;
                    allOrders.Add(aOrder);
                }
            }
            return allOrders;
        }
    }
}