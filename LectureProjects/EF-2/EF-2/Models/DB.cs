using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EF_2.Models
{
    public class DB:DbContext
    {       public DB() : base("name=DB")
            {
                Database.CreateIfNotExists();

                // NB: Må kjøres to ganger (start/stopp/start applikasjonen) når databasen ikke eksisterer
                Database.SetInitializer(new DBInit());
            }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }

            public virtual DbSet<Vare> Vare { get; set; }
            public virtual DbSet<Kunde> Kunde { get; set; }
            public virtual DbSet<Ordre> Ordre { get; set; }
            public virtual DbSet<OrdreLinje> OrdreLinjer { get; set; }
    }
}
