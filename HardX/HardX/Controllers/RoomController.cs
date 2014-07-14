using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;
using HardX.Utils;

namespace HardX.Controllers
{
    public class RoomController : Controller
    {
        //
        // GET: /Room/

        public ActionResult Index()
        {
            if (!Access.HasAccess(36))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Room model = new Room();
            List<Room> theListModel = new List<Room>();
            theListModel = (List<Room>)model.GetAll();

            return View(theListModel);
        }

        //
        // GET: /Room/Details/5

        public ActionResult Details(int id)
        {
            if (!Access.HasAccess(39))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            return View();
        }

        //
        // GET: /Room/Create

        public ActionResult Create()
        {
            if (!Access.HasAccess(37))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            RoomNew model = new RoomNew();
            return View(model);
        } 

        //
        // POST: /Room/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (!Access.HasAccess(37))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            try
            {
                Room model = new Room();
                model.Name = collection["Name"];
                model.House = (new House()).GetById(Convert.ToInt32(collection["House"]));
                model.Save(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Room/Edit/5
 
        public ActionResult Edit(int id)
        {
            if (!Access.HasAccess(38))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Room model = new Room();
            model = model.GetById(id);
            return View(model);
        }

        //
        // POST: /Room/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (!Access.HasAccess(38))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            try
            {
                Room model = new Room();
                model = model.GetById(id);
                model.Name = collection["Name"];
                model.House = (new House()).GetById(Convert.ToInt32(collection["House.Id"]));
                                

                model.Update(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Room/Delete/5
 
        public ActionResult Delete(int id)
        {
            if (!Access.HasAccess(40))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Room model = new Room();
            model = model.GetById(id);

            model.Delete(model);

            return RedirectToAction("Index");
        }

        //
        // POST: /Room/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (!Access.HasAccess(40))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
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
