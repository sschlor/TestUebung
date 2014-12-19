using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuchVerwaltung.Models
{
    public class Autor
    {
        public int ID { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public string Wohnort { get; set; }
        public virtual List<Buch> Buecher { get; set; }


        public Autor()
        {
            Buecher = new List<Buch>();
        }
    }
}