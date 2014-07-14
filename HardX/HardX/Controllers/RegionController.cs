using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;
using HardX.Utils;

namespace HardX.Controllers
{
    public class RegionController : Controller
    {
        //
        // GET: /Region/

        public ActionResult Index()
        {
            if (!Access.HasAccess(16))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Region model = new Region();
            List<Region> theListModel = new List<Region>();
            theListModel = (List<Region>)model.GetAll();

            return View(theListModel);
        }

        //
        // GET: /Region/Details/5

        public ActionResult Details(int id)
        {
            if (!Access.HasAccess(19))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            return View();
        }

        //
        // GET: /Region/Create

        public ActionResult Create()
        {
            if (!Access.HasAccess(17))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            RegionNew model = new RegionNew();
            return View(model);
        } 

        //
        // POST: /Region/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (!Access.HasAccess(17))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            try
            {
                Region model = new Region();
                model.Name = collection["Name"];
                model.State = (new State()).GetById(Convert.ToInt32(collection["State.ID"]));
                model.Save(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Region/Edit/5
 
        public ActionResult Edit(int id)
        {
            if (!Access.HasAccess(18))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Region model = new Region();
            model = model.GetById(id);
            return View(model);
        }

        //
        // POST: /Region/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (!Access.HasAccess(18))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            try
            {
                Region model = new Region();
                model = model.GetById(id);
                model.Name = collection["Name"];
                model.State = (new State()).GetById(Convert.ToInt32(collection["State.ID"]));
                model.Update(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Region/Delete/5
 
        public ActionResult Delete(int id)
        {
            if (!Access.HasAccess(20))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Region model = new Region();
            model = model.GetById(id);
            model.Delete(model);

            return RedirectToAction("Index");
        }

        //
        // POST: /Region/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (!Access.HasAccess(20))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
