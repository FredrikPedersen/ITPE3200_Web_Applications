using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaOrdering.Models
{
    public class Pizza
    {
        [Display(Name = "Pizza Type")]
        public string pizzaType {
            get; set;
        }

        [Display(Name = "Italian Style")]
        public bool thick {
            get; set;
        }

        [Display(Name = "Quantity")]
        public int quantity {
            get; set;
        }

        [Display(Name = "Full Name")]
        public string fullName {
            get; set;
        }

        [Display(Name = "Address")]
        public string address {
            get; set;
        }

        [Display(Name = "Phonenumber")]
        public int phoneNumber {
            get; set;
        }
    }
}