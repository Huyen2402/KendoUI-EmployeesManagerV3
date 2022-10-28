using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using KendoUI_EmployeesManagerV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult getList([DataSourceRequest] DataSourceRequest req)
        {
            List<Employees> list = db.Employees.ToList();
            return Json(list.ToDataSourceResult(req), JsonRequestBehavior.AllowGet);
        }
    }
}