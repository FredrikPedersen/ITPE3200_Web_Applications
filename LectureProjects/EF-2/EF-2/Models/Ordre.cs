using System.Collections.Generic;

namespace EF_2.Models
{
    public class Ordre
    {
        public int Id { get; set; }
        public string Dato { get; set; }
        public virtual Kunde Kunde { get; set; }
        public virtual List<OrdreLinje> OrdreLinjer { get; set; }
    }
}