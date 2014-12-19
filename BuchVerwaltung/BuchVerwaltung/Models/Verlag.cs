using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuchVerwaltung.Models
{
    public class Verlag
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Hauptsitz { get; set; }
        public string Chef { get; set; }

        public virtual List<Buch> Buecher { get; set; }

        public Verlag()
        {
            Buecher = new List<Buch>();
        }

    }
}