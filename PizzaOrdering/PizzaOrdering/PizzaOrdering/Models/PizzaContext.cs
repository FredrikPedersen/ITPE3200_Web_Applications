using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PizzaOrdering.Models
{

    public class Order
    {
        [Key]
        public int oId {
            get; set;
        }
        public string pizzaType {
            get; set;
        }
        public bool thick {
            get; set;
        }
        public int quantity {
            get; set;
        }
        public int cId {
            get; set;
        }
        public virtual OrderCustomer OrderCustomer {
            get; set;
        }
    }

    public class OrderCustomer
    {
        [Key]
        public int cId {
            get; set;
        }
        public string fullName {
            get; set;
        }
        public string address {
            get; set;
        }
        public int phoneNumber {
            get; set;
        }
        public virtual List<Order> orders {
            get; set;
        }
    }
    public class PizzaContext : DbContext
    {
        public PizzaContext() : base("name=Pizzas")
        {
            Database.CreateIfNotExists();
        }
        public DbSet<Order> orders {
            get; set;
        }
        public DbSet<OrderCustomer> orderCustomers {
            get; set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}