using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Datatable.AzureSql;

namespace Datatable.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {           
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
        public ActionResult Datatable1()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Datatable()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UpdateEmp(Datatable.Models.EmployeeModel model)
        {
            using (var db = new AzureDatatableEntities())
            {
                var result = db.Employees.SingleOrDefault(b => b.EmpId == model.EmpId);
                if (result != null)
                {
                    if (model.Property == "Name")
                        result.Name = model.Name;
                    if (model.Property == "Position")
                        result.Position = model.Position;
                    if (model.Property == "Location")
                        result.Office = model.Location;
                    if (model.Property == "Age")
                        result.Age = model.Age;
                    if (model.Property == "Salary")
                        result.Salary = model.Salary;
                    
                    db.SaveChanges();
                }
            }
            return Json(new { status = "success" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteEmpById(Datatable.Models.EmployeeModel model)
        {
            using (var ctx = new AzureDatatableEntities())
            {
                var employer = new AzureSql.Employee { EmpId = model.EmpId };
                ctx.Employees.Attach(employer);
                ctx.Employees.Remove(employer);
                ctx.SaveChanges();
            }
            return Json(new { status = "success" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult returnjson()
        {
            var context = new AzureDatatableEntities();
            var query = (from data in context.Employees
                         orderby data.EmpId
                         select new { EmpId = data.EmpId, Name = data.Name, Position = data.Position, Office = data.Office,  Age = data.Age ,Salary = data.Salary,Action=true }).ToList();
            return Json(query , JsonRequestBehavior.AllowGet);
           // string text = System.IO.File.ReadAllText(@"E:\Datatable\Datatable\App_Data\jsondata.txt", Encoding.UTF8);
            //return Content(text);
        }

    }
}
