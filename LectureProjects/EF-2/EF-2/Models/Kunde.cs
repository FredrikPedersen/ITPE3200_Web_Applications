using System.Collections.Generic;

namespace EF_2.Models
{
    public class Kunde
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public virtual List<Ordre> Ordre { get; set; }
    }
}