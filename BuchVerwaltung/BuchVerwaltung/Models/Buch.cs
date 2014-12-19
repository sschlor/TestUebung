using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuchVerwaltung.Models
{
    public class Buch
    {
        public int ID { get; set; }
        public string Titel { get; set; }
        public string Untertitel { get; set; }
        public int Seiten { get; set; }

        public virtual Sprache Sprache { get; set; }
        public virtual Land Erscheinungsland { get; set; }
        public virtual Verlag Verlag { get; set; }
        public virtual List<Autor> Autoren { get; set; }

        public Buch()
        {
            Autoren = new List<Autor>();
        }

    }
}