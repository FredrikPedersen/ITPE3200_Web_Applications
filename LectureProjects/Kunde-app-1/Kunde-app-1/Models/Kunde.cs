using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kunde_app_1.Models
{
    public class Kunde
    {
        public int id { get; set; }
        public string fornavn { get; set; }
        public string etternavn { get; set; }
        public string adresse { get; set; }
        public string postnr { get; set; }
        public string poststed { get; set; }
    }
}