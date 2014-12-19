using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuchVerwaltung.Models
{
    public class Sprache
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual List<Buch> Buecher { get; set; }

        public Sprache()
        {
            Buecher = new List<Buch>();
        }
    }
}