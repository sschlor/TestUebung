using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuchVerwaltung.Models
{
    public class Land
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Kuerzel { get; set; }

        public virtual List<Buch> Buecher { get; set; }

        public Land()
        {
            Buecher = new List<Buch>();
        }
    }
}