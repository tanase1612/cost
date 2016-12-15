using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestingADConection;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        Connection con = Connection.Instance;
        public ActionResult Index()
        {
          List<Person> users =  con.GetAllUsers().Values.ToList();
            return View(users);
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

        private Dictionary<string, string> GetAllUsers()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            return dic;
        }
    }
}