using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;
using HardX.Utils;

namespace HardX.Controllers
{
    public class MaterialController : Controller
    {
        //
        // GET: /Material/

        public ActionResult Index()
        {
            if (!Access.HasAccess(56))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            return View();
        }

        //
        // GET: /Material/Details/5

        public ActionResult Details(int id)
        {
            if (!Access.HasAccess(59))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            return View();
        }

        //
        // GET: /Material/Create

        public ActionResult Create()
        {
            if (!Access.HasAccess(57))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            return View();
        } 

        //
        // POST: /Material/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (!Access.HasAccess(57))
                {
                    System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                    route.Add("err", "Нет доступа!");
                    return RedirectToAction("Error", "Home", route);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Material/Edit/5
 
        public ActionResult Edit(int id)
        {
            if (!Access.HasAccess(58))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            return View();
        }

        //
        // POST: /Material/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                if (!Access.HasAccess(58))
                {
                    System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                    route.Add("err", "Нет доступа!");
                    return RedirectToAction("Error", "Home", route);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Material/Delete/5
 
        public ActionResult Delete(int id)
        {
            if (!Access.HasAccess(60))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Material item = new Material();
            item = item.GetById(id);
            item.Delete(item);
            return View();
        }

        //
        // POST: /Material/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (!Access.HasAccess(60))
                {
                    System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                    route.Add("err", "Нет доступа!");
                    return RedirectToAction("Error", "Home", route);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
