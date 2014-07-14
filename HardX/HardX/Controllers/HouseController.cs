using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;
using HardX.Utils;

namespace HardX.Controllers
{
    public class HouseController : Controller
    {
        //
        // GET: /House/

        public ActionResult Index()
        {
            if (!Access.HasAccess(31))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            House model = new House();
            List<House> theListModel = new List<House>();
            theListModel = (List<House>)model.GetAll();

            return View(theListModel);
        }

        //
        // GET: /House/Details/5

        public ActionResult Details(int id)
        {
            if (!Access.HasAccess(34))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            return View();
        }

        //
        // GET: /House/Create

        public ActionResult Create()
        {
            if (!Access.HasAccess(32))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            HouseNew model = new HouseNew();
            return View(model);
        }

        //
        // POST: /House/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (!Access.HasAccess(32))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            try
            {
                House model = new House();
                model.Name = collection["Name"];
                model.Street = (new Street()).GetById( Convert.ToInt32(collection["Street"]) );

                int AreaID = 0;
                try
                {
                    AreaID = Convert.ToInt32(collection["Area"]);
                    model.Area = (new Area()).GetById(AreaID);
                }
                catch
                {
                }
                
                model.Save(model);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", ex.Message);
                return RedirectToAction("Error", "Home", route);
            }
        }

        //
        // GET: /House/Edit/5

        public ActionResult Edit(int id)
        {
            if (!Access.HasAccess(33))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            House model = new House();
            model = model.GetById(id);
            return View(model);
        }

        //
        // POST: /House/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (!Access.HasAccess(33))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            try
            {
                House model = new House();
                model = model.GetById(id);
                model.Name = collection["Name"];
                model.Street = (new Street()).GetById(Convert.ToInt32(collection["Street"]));

                int AreaID = 0;
                try
                {
                    AreaID = Convert.ToInt32(collection["Area"]);
                    model.Area = (new Area()).GetById(AreaID);
                }
                catch
                {
                }

                model.Update(model);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", ex.Message);
                return RedirectToAction("Error", "Home", route);
            }
        }

        //
        // GET: /House/Delete/5

        public ActionResult Delete(int id)
        {
            if (!Access.HasAccess(35))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            try
            {
                House model = new House();
                model = model.GetById(id);
                model.Delete(model);

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
        // POST: /House/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (!Access.HasAccess(35))
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
