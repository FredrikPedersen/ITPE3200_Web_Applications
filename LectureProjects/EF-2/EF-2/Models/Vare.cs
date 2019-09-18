using System.Collections.Generic;

namespace EF_2.Models
{
    public class Vare
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public double Pris { get; set; }
        public virtual List<OrdreLinje> OrdreLinjer { get; set; }
    }
}