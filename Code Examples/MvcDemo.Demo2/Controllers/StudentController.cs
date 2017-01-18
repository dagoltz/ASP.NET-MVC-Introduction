using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Xml.Serialization;
using MvcDemo.Demo2.Models;

namespace MvcDemo.Demo2.Controllers
{
    public class StudentController : Controller
    {
        private const string LastViewedKey = "lazy-viewed";
        private static readonly Lazy<IList<Student>> StudentsHolder = new Lazy<IList<Student>>(GenerateStudents);
        private static IList<Student> GenerateStudents()
        {
            var xmlSerializer = new XmlSerializer(typeof (Student[]));
            var path = HostingEnvironment.MapPath("~/App_Data/students.xml");
            using (var file = System.IO.File.OpenRead(path))
            {
                return xmlSerializer.Deserialize(file) as Student[];
            }
        }

        //
        // GET: /Student/
        public ActionResult Index()
        {
            ViewBag.Last = TempData[LastViewedKey];

            return View(StudentsHolder.Value);
        }

        //
        // GET: /Student/Details/6
        public ActionResult Details(int id)
        {
            var student = StudentsHolder.Value.First(s => s.Id == id);
            TempData[LastViewedKey] = student;

            return View(student);
        }

    }
}
