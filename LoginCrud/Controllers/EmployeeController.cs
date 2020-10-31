using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginCrud.Models;

namespace LoginCrud.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        [OutputCache(Duration =20)]
        public ActionResult Index()
        {
            List<Employee> emp = new List<Employee>()
            {
                new Employee(){Id=1,FirstName="Akash",Email="Akash@gmail.com",LastName="Vaishali"},
                new Employee(){Id=1,FirstName="Akash",Email="Akash@gmail.com",LastName="Vaishali"},
                new Employee(){Id=1,FirstName="Akash",Email="Akash@gmail.com",LastName="Vaishali"},
                new Employee(){Id=1,FirstName="Akash",Email="Akash@gmail.com",LastName="Vaishali"},
                new Employee(){Id=1,FirstName="Akash",Email="Akash@gmail.com",LastName="Vaishali"}
            };
            return View(emp);
        }
    }
}