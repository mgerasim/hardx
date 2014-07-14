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
            if (!Access.HasAccess(41))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            
            Area model = new Area();
            List<Area> theListModel = new List<Area>();
            theListModel = (List<Area>)model.GetAll();

            return View(theListModel);
        }

        //
        // GET: /Area/Details/5

        public ActionResult Details(int id)
        {
            if (!Access.HasAccess(44))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Area model = new Area();
            return View(model.GetById(id));
        }

        //
        // GET: /Area/Create

        public ActionResult Create()
        {
            if (!Access.HasAccess(42))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            AreaNew model = new AreaNew();
            return View(model);
        }

        //
        // POST: /Area/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (!Access.HasAccess(42))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            try
            {
                // TODO: Add insert logic here
                Area model = new Area();
                model.Name = collection["Name"];

                if (collection["User.ID"] != null)
                {
                    model.User = (new User()).GetById(Convert.ToInt32(collection["User.ID"]));
                }

                if (collection["Store.ID"] != "")
                {
                    model.Store = (new Store()).GetById(Convert.ToInt32(collection["Store.ID"]));
                }

                string IDs = collection["HouseSelections"];

                if (IDs!=null)
                {
                    foreach (string item in IDs.Split(','))
                    {
                        model.Houses.Add((new House()).GetById(Convert.ToInt32(item)));
                    }
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
            if (!Access.HasAccess(43))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Area model = new Area();
            model = model.GetById(id);
            return View(model);
        }

        //
        // POST: /Area/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (!Access.HasAccess(43))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            try
            {
                // TODO: Add update logic here
                Area model = new Area();
                model = model.GetById(id);
                model.Name = collection["Name"];
                if (collection["User.ID"] != null)
                {
                    model.User = (new User()).GetById(Convert.ToInt32(collection["User.ID"]));
                }

                if (collection["Store.ID"] != "")
                {
                    model.Store = (new Store()).GetById(Convert.ToInt32(collection["Store.ID"]));
                }

                string IDs = collection["HouseSelections"];

                if (IDs != null)
                {
                    model.Houses.Clear();
                    model.Update(model);

                    foreach (string item in IDs.Split(','))
                    {
                        model.Houses.Add((new House()).GetById(Convert.ToInt32(item)));
                    }
                }

                model.Update(model);

                return RedirectToAction("Edit", new { id = model.Id});
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
            if (!Access.HasAccess(45))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Area model = new Area();
            model = model.GetById(id);
            model.Delete(model);

            return RedirectToAction("Index");
        }
        
    }
}
