
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private RestUsers ru = new RestUsers();
        
        public async Task< ActionResult> Index()
        {
            List<Person> list = await ru.GetUsersAsync();
            //list.Sort();
            return View(list);
        }

        public async Task< ActionResult> About()
        {
            var list = await  ru.GetUsersAsync();
           // ViewBag.Message = list.FirstOrDefault().ToString();

            return View(list);
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