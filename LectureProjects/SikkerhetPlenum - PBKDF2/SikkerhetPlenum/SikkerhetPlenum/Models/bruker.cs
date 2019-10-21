using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SikkerhetPlenum.Models
{
   
        public class bruker
        {
            [Required(ErrorMessage = "Navn må oppgis")]
            public string Navn { get; set; }
            [Required(ErrorMessage = "Passord må oppgis")]
            public string Passord { get; set;}
        }

        public class dbBruker
        {
            [Key]
            public string Navn { get; set; }
            public byte[] Passord { get; set; }

            public byte[] Salt { get; set; }
        }

        public class BrukerContext : DbContext
        {
            public BrukerContext()
                : base("name=Bruker")
            {
                Database.CreateIfNotExists();
            }

            public DbSet<dbBruker> Brukere { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        }
}