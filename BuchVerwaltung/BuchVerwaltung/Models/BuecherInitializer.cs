using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BuchVerwaltung.Models
{
    public class BuecherInitializer : DropCreateDatabaseIfModelChanges<BuecherContext>
    {
        protected override void Seed(BuecherContext context)
        {
            base.Seed(context);

            Sprache de = new Sprache { Name = "Deutsch" };
            Sprache en = new Sprache { Name = "Englisch" };
            Sprache fr = new Sprache { Name = "Französisch" };
            context.Sprachen.AddRange(new Sprache[] { de, en, fr });

            Verlag v1 = new Verlag { Chef = "Jürgen Fattinger", Hauptsitz = "St. Agatha", Name = "Fattinger Verlag" };
            Verlag v2 = new Verlag { Chef = "Andreas Stöbich", Hauptsitz = "Oberrudling", Name = "Stöbich VL" };
            context.Verlage.AddRange(new Verlag[] { v1, v2 });

            Land l1 = new Land { Name = "Österreich", Kuerzel = "AUT" };
            Land l2 = new Land { Name = "Deutschland", Kuerzel = "DEU" };
            Land l3 = new Land { Name = "Frankreich", Kuerzel = "FRA" };
            Land l4 = new Land { Name = "England", Kuerzel = "ENG" };
            context.Laender.AddRange(new Land[] { l1, l2, l3, l4 });

            Autor a1 = new Autor { Vorname = "Stefan", Nachname = "Schlor", Geburtsdatum = new DateTime(1995, 12, 27), Wohnort = "Pichl bei Wels" };
            Autor a2 = new Autor { Vorname = "Florian", Nachname = "Hiegelsberger", Geburtsdatum = new DateTime(1996, 3, 12), Wohnort = "Krenglbach" };
            Autor a3 = new Autor { Vorname = "Simon", Nachname = "Dietrich", Geburtsdatum = new DateTime(1996, 4, 8), Wohnort = "Dorf an der Pram" };
            Autor a4 = new Autor { Vorname = "Patrick", Nachname = "Bouda", Geburtsdatum = new DateTime(1992, 12, 30), Wohnort = "St. Florian am Inn" };
            Autor a5 = new Autor { Vorname = "Gabriel", Nachname = "Unterholzer", Geburtsdatum = new DateTime(1995, 11, 18), Wohnort = "Wernstein am Inn" };
            context.Autoren.AddRange(new Autor[] { a1, a2, a3, a4, a5 });

            Buch b1 = new Buch { Titel = "Harry Potter und der Stein der Weisen", Erscheinungsland = l4, Seiten = 1114, Sprache = en, Verlag = v1 };
            b1.Autoren.Add(a5);
            Buch b2 = new Buch { Titel = "Harry Potter und die Kammer des Schreckens", Erscheinungsland = l4, Seiten = 1027, Sprache = en, Verlag = v1 };
            b2.Autoren.Add(a5);
            Buch b3 = new Buch { Titel = "Harry Potter und der Gefangene von Askhaban", Erscheinungsland = l4, Seiten = 1250, Sprache = en, Verlag = v1 };
            b3.Autoren.Add(a5);
            Buch b4 = new Buch { Titel = "Das Benzingeld", Erscheinungsland = l1, Seiten = 526, Sprache = de, Verlag = v2 };
            b4.Autoren.Add(a1);
            b4.Autoren.Add(a2);
            Buch b5 = new Buch { Titel = "L'Amour Toujours", Erscheinungsland = l3, Seiten = 312, Sprache = fr, Verlag = v1 };
            b5.Autoren.Add(a3);
            Buch b6 = new Buch { Titel = "Das Gericht", Erscheinungsland = l2, Seiten = 738, Sprache = de, Verlag = v2 };
            b6.Autoren.Add(a3);
            b6.Autoren.Add(a4);
            context.Buecher.AddRange(new Buch[] { b1, b2, b3, b4, b5, b6 });

            context.SaveChanges();

        }
    }
}