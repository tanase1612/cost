﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI.DAL;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        Repository repo = new Repository();

        public ActionResult Index()
        {
          var items=   repo.GetAll();
            Console.WriteLine("I am here");
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {

            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("Index");
        }


    }
}
