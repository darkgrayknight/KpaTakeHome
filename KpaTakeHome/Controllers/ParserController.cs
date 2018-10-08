using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using KpaTakeHome.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KpaTakeHome.Controllers
{
    public class ParserController : Controller
    {
        public ActionResult Display()
        {
            var db = new ParserDbContext();
            var set = db.Person;
            var people = set.ToList();
            ViewData.Add("People", people);
            return View();
        }

        // GET: Upload
        public ActionResult Upload()
        {
            return View();
        }

        // POST: Upload/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(IFormFile file)
        {
            try {
                var db = new ParserDbContext();
                var stream = Request.Form.Files[0].OpenReadStream();
                var reader = new StreamReader(stream);
                db.Person.AddRange(ReadStream(reader));
                db.SaveChanges();
                return RedirectToAction(nameof(Display));
            } catch {
                return View("Error");
            }
        }

        public static List<Person> ReadStream(StreamReader reader)
        {
            var list = new List<Person>();
            var csv = new CsvReader(reader);
            csv.Configuration.MissingFieldFound = null;
            csv.Read();
            csv.ReadHeader();
            while (csv.Read()) {
                var record = csv.Parser.Context.Record;
                list.Add(new Person(record));
            }
            return list;
        }
    }
}