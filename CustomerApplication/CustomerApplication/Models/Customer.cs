using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerApplication.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public virtual List<Order> Order { get; set; }
    }
}