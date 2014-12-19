using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BuchVerwaltung.Models
{
    public class BuecherContext : DbContext
    {
        public DbSet<Autor> Autoren { get; set; }
        public DbSet<Buch> Buecher { get; set; }
        public DbSet<Land> Laender { get; set; }
        public DbSet<Sprache> Sprachen { get; set; }
        public DbSet<Verlag> Verlage { get; set; }


    }
}