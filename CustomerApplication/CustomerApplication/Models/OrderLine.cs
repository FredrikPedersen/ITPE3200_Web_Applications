using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerApplication.Models
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}