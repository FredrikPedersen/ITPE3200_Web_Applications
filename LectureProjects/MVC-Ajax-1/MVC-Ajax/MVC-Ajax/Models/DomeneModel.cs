﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Ajax.Models
{
    public class domeneKunde
    {
        public int id { get; set; }
       
        public string fornavn { get; set; }
        public string etternavn { get; set; }
        public string adresse { get; set; }
        public string postnr { get; set; }
        public string poststed { get; set; }
    }

    public class jsKunde
    {
        public int id { get; set; }
        public string navn { get; set; }
    }
}