using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationAndLogin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            if (Session["username"] == null) 
            {
                return RedirectToAction("Index","Login");
            }
            else
            {
                
                return View();
            }
           
            
        }

        public ActionResult Logout() 
        { 
            Session.Abandon();
            return RedirectToAction("Login", "Home");
        }
    }
}