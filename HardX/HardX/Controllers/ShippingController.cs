using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;
using HardX.Utils;

namespace HardX.Controllers
{
    public class ShippingController : Controller
    {
        //
        // GET: /Shipping/

        public ActionResult Index()
        {
            if (!Access.HasAccess(71))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }

            Shipping model = new Shipping();
            List<Shipping> theListModel = new List<Shipping>();
            theListModel = (List<Shipping>)model.GetAll("","ID DESC");

            return View(theListModel);
        }

        //
        // GET: /Shipping/Details/5

        public ActionResult Details(int id)
        {
            if (!Access.HasAccess(74))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            return View();
        }

        public ActionResult CreateAjax(string name)
        {
            if (!Access.HasAccess(72))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Shipping theShipping = new Shipping();
            theShipping.Name = name;
            theShipping.Save(theShipping);

            return View(theShipping);
        }

        //
        // GET: /Shipping/Create

        public ActionResult Create()
        {
            if (!Access.HasAccess(72))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            ShippingNew model = new ShippingNew();
            return View(model);
        } 

        //
        // POST: /Shipping/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (!Access.HasAccess(72))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            try
            {
                Shipping model = new Shipping();
                model.Name = collection["Name"];
                model.Save(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Shipping/Edit/5
 
        public ActionResult Edit(int id)
        {
            if (!Access.HasAccess(73))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Shipping model = new Shipping();
            model = model.GetById(id);
            return View(model);
        }

        //
        // POST: /Shipping/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (!Access.HasAccess(13))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            try
            {
                Shipping model = new Shipping();
                model = model.GetById(id);
                model.Name = collection["Name"];
                model.Update(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Shipping/Delete/5
 
        public ActionResult Delete(int id)
        {
            if (!Access.HasAccess(75))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Shipping model = new Shipping();
            model = model.GetById(id);
            model.Delete(model);

            return RedirectToAction("Index");
        }

        //
        // POST: /Shipping/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (!Access.HasAccess(75))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Shipping model = new Shipping();
            model = model.GetById(id);
            model.Delete(model);

            return RedirectToAction("Index");
        }
    }
}
