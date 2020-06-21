using StuRegistrationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StuRegistrationApp.Controllers
{
    public class LoginController : Controller
    {

        StudentRegistrationDBEntities5 db = new StudentRegistrationDBEntities5();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user logedUser)
        {


            if (ModelState.IsValid)
            {
                var obj = db.users.Where(a => a.uername.Equals(logedUser.uername) && a.password.Equals(logedUser.password)).FirstOrDefault();

                if (obj != null)
                {
                    Session["UserId"] = obj.Id.ToString();
                    Session["UserName"] = obj.uername.ToString();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "The Username or Password incorrect");
                }
            }

            return View(logedUser);           
        }


        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}