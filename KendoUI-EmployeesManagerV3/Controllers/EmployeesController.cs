using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using KendoUI_EmployeesManagerV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Routing;

namespace KendoUI_EmployeesManagerV3.Controllers
{
    public class EmployeesController : Controller
    {
        ManageEmployeesTestEntities db = new ManageEmployeesTestEntities();
        // GET: Employees
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult getList([DataSourceRequest] DataSourceRequest req)
        {
            List<Employees> list = db.Employees.ToList();
            return Json(list.ToDataSourceResult(req), JsonRequestBehavior.AllowGet);
        }


        public JsonResult Delete([DataSourceRequest] DataSourceRequest req, Employees e)
        {
            if (e == null)
            {
                Response.StatusCode = 404;
            }
            else
            {
                Employees User = db.Employees.SingleOrDefault(n => n.Id == e.Id);
                if (User == null)
                {
                    Response.StatusCode = 404;
                }
                else
                {
                    db.Employees.Remove(User);
                    db.SaveChanges();

                }

            }
            return Json(ModelState.IsValid ? true : ModelState.ToDataSourceResult());
        }

        public JsonResult Create([DataSourceRequest] DataSourceRequest req, Employees e)
        {

            Employees newEmployee = new Employees();

            newEmployee.Name = e.Name;
            newEmployee.Email = e.Email;
            newEmployee.Address = e.Address;
            newEmployee.Phone = e.Phone;

            db.Employees.Add(newEmployee);
            db.SaveChanges();

            return Json(ModelState.IsValid ? true : ModelState.ToDataSourceResult());


        }
        public JsonResult Update([DataSourceRequest] DataSourceRequest req, Employees e)
        {

            Employees editEmployee = db.Employees.SingleOrDefault(n => n.Id == e.Id);
            if(editEmployee != null)
            {
                editEmployee.Name = e.Name;
                editEmployee.Email = e.Email;
                editEmployee.Address = e.Address;
                editEmployee.Phone = e.Phone;

             
                db.SaveChanges();
            }

            

            return Json(ModelState.IsValid ? true : ModelState.ToDataSourceResult());


        }


    }
}