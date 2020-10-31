using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LoginCrud.Models;

namespace LoginCrud.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Membership membership)
        {
            using (var context=new PracticeEntities())
            {
                bool isvalid = context.Users.Any(x => x.UserName == membership.UserName && x.Password == membership.Password);
                if(isvalid)
                {
                    FormsAuthentication.SetAuthCookie(membership.UserName, false);
                    return RedirectToAction("Index", "Offices");
                }
                ModelState.AddModelError("", "Invalid userName and Password");
                return View();
            }
             
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Users model)
        {
            using (var context=new PracticeEntities())
            {
                context.Users.Add(model);
                context.SaveChanges();
            }
                return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}