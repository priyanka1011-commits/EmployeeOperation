using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeDetails.Models;

namespace EmployeeDetails.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeOperations emp = new EmployeeOperations();

        //GET
        [HttpGet]
        public ActionResult Display(string Salary, string Age, string Location)
        {
            ModelState.Clear();
            return View(emp.getData(Salary, Age, Location));
        }

        //Employee/Delete/5
        public ActionResult Delete(int id)
        {
            emp.Delete(id);
            return RedirectToAction("Display");
        }
    }
}
