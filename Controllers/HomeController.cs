using RegistrationAndLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI.WebControls;

namespace RegistrationAndLogin.Controllers
{
    public class HomeController : Controller
    {
        RegistrationEntities1 db = new RegistrationEntities1();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Signup p)
        {
            if (ModelState.IsValid)
            {
               db.Signups.Add(p);
              int a =  db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.message = "Registration successfully";
                    ModelState.Clear();
                }
                else 
                {
                    ViewBag.message = "Registration failed";
                }

            }
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Signup a)
        {
            if (ModelState.IsValid == true) 
            {
                var data = db.Signups.Where(x => x.username == a.username && x.password == a.password).FirstOrDefault();
                if (data != null)
                {
                    Session["username"] = a.username.ToString();
                    TempData["message"] = "Login Successfully !!!";
                    ModelState.Clear();
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ViewBag.message = "Login failed try again";
                }
            }
            return View(a);
        }


    }
}