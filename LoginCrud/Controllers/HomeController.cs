using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginCrud.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            try
            {
                throw new Exception("");
            }
            catch (Exception EXC)
            {
                ExceptionChecking.WriteErrorLogInFile(EXC, "UtilizationTrackerWebApp", "Demo", "Index", "", "", "");
            }

             return View();
        }
    }
}