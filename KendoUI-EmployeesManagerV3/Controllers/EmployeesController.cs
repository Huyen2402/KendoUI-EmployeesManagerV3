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
        public ActionResult getList([DataSourceRequest] DataSourceRequest req)
        {
            List<Employees> list = db.Employees.ToList();
            return Json(list.ToDataSourceResult(req), JsonRequestBehavior.AllowGet);
        }

        
        //public ActionResult Delete([DataSourceRequest] DataSourceRequest req , Employees e)
        //{
        //    if(e == null)
        //    {
        //        Response.StatusCode = 404;
        //    }
        //    else
        //    {
        //        Employees User = db.Employees.SingleOrDefault(n => n.Id == e.Id);
        //        if(User == null)
        //        {
        //            Response.StatusCode = 404;
        //        }
        //        else
        //        {
        //            db.Employees.Remove(User);
        //            db.SaveChanges();
                   
        //        }
               
        //    }
        //   return View();
        //}

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(Employees product)
        {
            RouteValueDictionary routeValues;

            //Delete the record
            db.Employees.Remove(product);

            routeValues = this.GridRouteValues();

            //Redisplay the grid
            return RedirectToAction("Index", routeValues);
        }
    }
}