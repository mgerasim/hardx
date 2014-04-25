using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Utils;
using HardX.Models;

namespace HardX.Controllers
{
    public class AreaController : Controller
    {
        //
        // GET: /Area/

        public ActionResult Index()
        {
            /*
            if (!Access.HasAccess(6))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Capital", route);
            }
            */
            Area model = new Area();
            List<Area> theListModel = new List<Area>();
            theListModel = (List<Area>)model.GetAll();

            return View(theListModel);
        }

        //
        // GET: /Area/Details/5

        public ActionResult Details(int id)
        {
            /*
            if (!Access.HasAccess(6))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Capital", route);
            }
            */
            Area model = new Area();
            return View(model.GetById(id));
        }

        //
        // GET: /Area/Create

        public ActionResult Create()
        {
            /*
            if (!Access.HasAccess(5))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Capital", route);
            }
            */
            AreaNew model = new AreaNew();
            return View(model);
        }

        //
        // POST: /Area/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            /*
            if (!Access.HasAccess(5))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Capital", route);
            }
            */
            try
            {
                // TODO: Add insert logic here
                Area model = new Area();
                model.Name = collection["Name"];
                model.User = (new User()).GetById(Convert.ToInt32(collection["User.ID"]));

                string IDs = collection["RoomSelections"];
                
                foreach (string item in IDs.Split(','))
                {
                    model.Rooms.Add((new Room()).GetById(Convert.ToInt32(item)));
                }

                model.Save(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", ex.Message);
                return RedirectToAction("Error", "Home", route);
            }
        }

        //
        // GET: /Area/Edit/5

        public ActionResult Edit(int id)
        {
            /*
            if (!Access.HasAccess(7))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Capital", route);
            }
            */
            Area model = new Area();
            model = model.GetById(id);
            return View(model);
        }

        //
        // POST: /Area/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            /*
            if (!Access.HasAccess(7))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Capital", route);
            }
            */
            try
            {
                // TODO: Add update logic here
                Area model = new Area();
                model = model.GetById(id);
                model.Name = collection["Name"];
                model.User = (new User()).GetById(Convert.ToInt32(collection["User.ID"]));
                string IDs = collection["RoomSelections"];

                model.Rooms.Clear();
                model.Update(model);

                foreach (string item in IDs.Split(','))
                {
                    model.Rooms.Add((new Room()).GetById(Convert.ToInt32(item)));
                }

                model.Update(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", ex.Message);
                return RedirectToAction("Error", "Home", route);
            }
        }

        //
        // GET: /Area/Delete/5

        public ActionResult Delete(int id)
        {
            /*
            if (!Access.HasAccess(8))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Capital", route);
            }*/
            Area model = new Area();
            model = model.GetById(id);
            model.Delete(model);

            return RedirectToAction("Index");
        }
        
    }
}
