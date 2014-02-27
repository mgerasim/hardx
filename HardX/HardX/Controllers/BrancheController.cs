using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;
using HardX.Utils;

namespace HardX.Controllers
{
    public class BrancheController : Controller
    {
        //
        // GET: /Branch/

        public ActionResult Index()
        {
            if (!Access.HasAccess(6))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Capital", route);
            }
            Branche theBranche = new Branche();
            List<Branche> theListBranche = new List<Branche>();
            theListBranche = (List<Branche>)theBranche.GetAll();

            return View(theListBranche);
        }

        //
        // GET: /Branch/Details/5

        public ActionResult Details(int id)
        {
            if (!Access.HasAccess(6))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Capital", route);
            }
            Branche theBranche = new Branche();            
            return View(theBranche.GetById(id));
        }

        //
        // GET: /Branch/Create

        public ActionResult Create()
        {
            if (!Access.HasAccess(5))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Capital", route);
            }
            BrancheNew theBranch = new BrancheNew();  
            return View(theBranch);
        } 

        //
        // POST: /Branch/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (!Access.HasAccess(5))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Capital", route);
            }
            try
            {
                // TODO: Add insert logic here
                Branche theBranche = new Branche();                
                theBranche.FullName = collection["FullName"];
                theBranche.ShortName = collection["ShortName"];
                theBranche.Save(theBranche);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Branch/Edit/5
 
        public ActionResult Edit(int id)
        {
            if (!Access.HasAccess(7))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Capital", route);
            }
            Branche theBranche = new Branche();
            theBranche = theBranche.GetById(id);
            return View(theBranche);
        }

        //
        // POST: /Branch/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (!Access.HasAccess(7))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Capital", route);
            }
            try
            {
                // TODO: Add update logic here
                Branche theBranche = new Branche();                
                theBranche = theBranche.GetById(id);
                theBranche.FullName  = collection["FullName"];
                theBranche.ShortName = collection["ShortName"];
                theBranche.Update(theBranche);
                                               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Branch/Delete/5
 
        public ActionResult Delete(int id)
        {
            if (!Access.HasAccess(8))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Capital", route);
            }
            Branche theBranche = new Branche();
            theBranche = theBranche.GetById(id);
            theBranche.Delete(theBranche);

            return RedirectToAction("Index");
        }

        //
        // POST: /Branch/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (!Access.HasAccess(8))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Capital", route);
            }
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
