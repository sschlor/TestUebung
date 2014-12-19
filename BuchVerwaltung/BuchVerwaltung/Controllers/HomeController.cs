using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuchVerwaltung.Models;
using System.Data.Entity;

namespace BuchVerwaltung.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            Database.SetInitializer(new BuecherInitializer());
            var db = new BuecherContext();


            return View();
        }

        public JsonResult LadeTree()
        {
            var db = new BuecherContext();
            var data = new List<Dictionary<string, object>>();

            var node = new Dictionary<string, object>();
            node["title"] = "Autoren";
            node["key"] = "autoren";
            node["isFolder"] = true;
            node["isLazy"] = true;
            data.Add(node);

            node = new Dictionary<string, object>();
            node["title"] = "Bücher";
            node["key"] = "buecher";
            node["isFolder"] = true;
            node["isLazy"] = true;
            data.Add(node);
            node = new Dictionary<string, object>();
            node["title"] = "Länder";
            node["key"] = "laender";
            node["isFolder"] = true;
            node["isLazy"] = true;
            data.Add(node);
            node = new Dictionary<string, object>();
            node["title"] = "Sprachen";
            node["key"] = "sprachen";
            node["isFolder"] = true;
            node["isLazy"] = true;
            data.Add(node);
            node = new Dictionary<string, object>();
            node["title"] = "Verlage";
            node["key"] = "verlage";
            node["isFolder"] = true;
            node["isLazy"] = true;
            data.Add(node);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LadeSubTree(string nodeKey)
        {
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            switch (nodeKey)
            {
                case "autoren": { data = LoadAutoren(); break; }
                case "buecher": { data = LoadBuecher(); break; }
                case "laender": { data = LoadLaender(); break; }
                case "sprachen": { data = LoadSprachen(); break; }
                case "verlage": { data = LoadVerlage(); break; }
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        private List<Dictionary<string, object>> LoadVerlage()
        {
            var db = new BuecherContext();
            List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();

            foreach (var x in db.Verlage.OrderBy(x => x.Name))
            {
                var node = new Dictionary<string, object>();
                node["title"] = x.Name;
                node["key"] = "verlag;" + x.ID;
                node["isFolder"] = false;
                node["isLazy"] = false;
                result.Add(node);
            }
            return result;
        }

        private List<Dictionary<string, object>> LoadSprachen()
        {
            var db = new BuecherContext();
            List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();

            foreach (var x in db.Sprachen.OrderBy(x => x.Name))
            {
                var node = new Dictionary<string, object>();
                node["title"] = x.Name;
                node["key"] = "sprache;" + x.ID;
                node["isFolder"] = false;
                node["isLazy"] = false;
                result.Add(node);
            }
            return result;
        }

        private List<Dictionary<string, object>> LoadLaender()
        {
            var db = new BuecherContext();
            List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();

            foreach (var x in db.Laender.OrderBy(x => x.Name))
            {
                var node = new Dictionary<string, object>();
                node["title"] = x.Name;
                node["key"] = "land;" + x.ID;
                node["isFolder"] = false;
                node["isLazy"] = false;
                result.Add(node);
            }
            return result;
        }

        private List<Dictionary<string, object>> LoadBuecher()
        {
            var db = new BuecherContext();
            List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();

            foreach (var x in db.Buecher.OrderBy(x => x.Titel))
            {
                var node = new Dictionary<string, object>();
                node["title"] = x.Titel+"; "+x.Verlag.Name;
                node["key"] = "buch;" + x.ID;
                node["isFolder"] = false;
                node["isLazy"] = false;
                result.Add(node);
            }
            return result;
        }

        private List<Dictionary<string, object>> LoadAutoren()
        {
            var db = new BuecherContext();
            List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();

            foreach (var x in db.Autoren.OrderBy(x => x.Nachname))
            {
                var node = new Dictionary<string, object>();
                node["title"] = x.Nachname + ", " + x.Vorname + "; " + x.Wohnort;
                node["key"] = "autor;" + x.ID;
                node["isFolder"] = false;
                node["isLazy"] = false;
                result.Add(node);
            }
            return result;
        }
    
        public JsonResult LadeGrid(int page, int rows, string sidx, string sord)
        {
            var db = new BuecherContext();

            int totalPages = 0;
            int nrRecords = 0;
            var list = new List<object>();

            try
            {
                var recs = from book in db.Buecher select book;
                recs = sidx == "Title" ? (recs.OrderBy(x => x.Titel)) : (recs.OrderBy(x => x.ID));

                nrRecords = recs.Count();
                totalPages = Convert.ToInt32(Math.Ceiling((nrRecords * 1.0) / rows));
                var result = recs.Skip((page - 1) * rows).Take(rows).ToList();
                foreach(var rec in result)
                {
                    var data = new List<object>();

                    data.Add(rec.ID);
                    data.Add(rec.Titel);
                    data.Add(rec.Autoren.First().Nachname + ", " + rec.Autoren.First().Vorname);
                    data.Add(rec.Verlag.Name);
                    data.Add(rec.Sprache.Name);
                    data.Add(rec.Seiten);
                    list.Add(new { id = rec.ID, cell = data });
                }
            }
            catch(Exception exc)
            {
                list.Add(exc.Message);
            }
            var response = new { total = totalPages, page = page, records = nrRecords, rows = list };
            var d = Json(response, JsonRequestBehavior.AllowGet);
            return d;
        }
    }
}
