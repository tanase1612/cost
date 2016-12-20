using ClientChemInfo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientChemInfo.Controllers
{
    public class HomeController : Controller
    {
        private ExcelReader efiles = new ExcelReader();
        private List<Person> mergeList = new List<Person>();
        private List<Person> initialList = new List<Person>();
        public ActionResult Index()
        {
            seedData();
            return View(initialList);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(HttpPostedFileBase file)
        {
            seedData();
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
              
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
                //List<Person> m = initialList.Where(p => efiles.RetrieveRecordes(path.ToString()).Any(s => p.Name == s)).ToList();
                foreach (Person per in efiles.RetrieveRecordes(path.ToString()))
                {
                    foreach (var pt in initialList)
                    {
                        if (per.Name == pt.Name)
                            mergeList.Add(pt);
                    }
                 
                    mergeList.Add(per);
                }
                System.IO.File.Delete(path);
                List<Person> sorted = mergeList.ToLookup(p => p.Name).Select(coll => coll.First()).ToList();
                return View(sorted);
            }
            return View(initialList);
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private List<Person> seedData()
        {
            for (int i = 0; i < 1000; i++)
            {

                Person per = new Person
                {
                    ID = 10 + i,
                    Name = "Adi Tanase " + i.ToString(),
                    Position = "Same" + i.ToString(),
                    Office = "Dubai" + i.ToString(),
                    ChemCost = "44646 IT" + i.ToString(),
                    FMCCost = " Not implemented " + i.ToString(),
                    Phone = "46446" + i.ToString()
                };
                initialList.Add(per);
            }
            return initialList;
        }
    }
}