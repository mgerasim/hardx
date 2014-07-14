using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;
using HardX.Utils;

namespace HardX.Controllers
{
    public class MatmodelController : Controller
    {
        //
        // GET: /Matmodel/

        public ActionResult Index()
        {
            if (!Access.HasAccess(61))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            List<Matmodel> theListMatmodel = new List<Matmodel>();
            Matmodel theMatmodel = new Matmodel();
            theListMatmodel = (List<Matmodel>)theMatmodel.GetAll();

            return View(theListMatmodel);
        }

        public ActionResult Compatibility(int ID)
        {
            if (!Access.HasAccess(61))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Matmodel model = new Matmodel();
            model = model.GetById(ID);

            return View(model);
        }

        [HttpPost]
        public ActionResult Compatibility(int ID, FormCollection collection)
        {
            if (!Access.HasAccess(61))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Matmodel model = new Matmodel();
            model = model.GetById(ID);

            string IDs = collection["DevmodelSelections"];

            model.Devmodels.Clear();
            model.Update(model);

            foreach (string item in IDs.Split(','))
            {
                model.Devmodels.Add((new Devmodel()).GetById(Convert.ToInt32(item)));
            }

            model.Update(model);

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            if (!Access.HasAccess(62))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            NewMatmodel model = new NewMatmodel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (!Access.HasAccess(62))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            try {
                Matmodel model = new Matmodel();
                model.Name = collection["Name"];
                model.Partnumber = collection["Partnumber"];
                model.Capacity = Convert.ToInt32(collection["Capacity"]);
                model.Price = Convert.ToInt32(collection["Price"]);
                model.Vendor = (new Vendor()).GetById(Convert.ToInt32(collection["VendorID"]));
                model.Typedev = (new Typedev()).GetById(Convert.ToInt32(collection["TypedevID"]));
                model.Save(model);
                
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public ActionResult Edit(int ID)
        {
            if (!Access.HasAccess(63))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Matmodel model = new Matmodel();
            model = model.GetById(ID);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int ID, FormCollection collection)
        {
            if (!Access.HasAccess(63))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            try
            {
                Matmodel model = new Matmodel();
                model = model.GetById(ID);

                model.Name = collection["Name"];
                model.Partnumber = collection["Partnumber"];
                model.Capacity = Convert.ToInt32(collection["Capacity"]);
                model.Price = Convert.ToInt32(collection["Price"]);
                model.Vendor = (new Vendor()).GetById(Convert.ToInt32(collection["VendorID"]));
                model.Typedev = (new Typedev()).GetById(Convert.ToInt32(collection["TypedevID"]));
                model.Update(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public ActionResult Delete(int ID)
        {
            if (!Access.HasAccess(65))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            try
            {
                Matmodel model = new Matmodel();
                model = model.GetById(ID);
                model.Delete(model);
                return RedirectToAction("Index");            
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

    }
}
