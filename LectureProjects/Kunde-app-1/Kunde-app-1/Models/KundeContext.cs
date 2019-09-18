using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Kunde_app_1.Models
{

    public class Kunder
    {
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public virtual Poststeder Poststeder { get; set; }
    }

    public class Poststeder
    {
        [Key]
        public string Postnr { get; set; }
        public string Poststed { get; set; }
        public virtual List<Kunder> Kunder { get; set; }
    }


    public class KundeContext : DbContext
    {

        public KundeContext() : base("name=Kunder")
        {
            Database.CreateIfNotExists();
        }
        public DbSet<Kunder> Kunder { get; set; }
        public DbSet<Poststeder> Poststeder { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}