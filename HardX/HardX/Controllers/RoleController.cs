using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Repositories;
using HardX.Models;
using HardX.Utils;

namespace HardX.Controllers
{
    public class RoleController : Controller
    {
        //
        // GET: /Role/

        public ActionResult Index()
        {
            if (!Access.HasAccess(10))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Capital", route);
            }
            RoleRepository theRoleRepository = new RoleRepository();
            return View(theRoleRepository.GetAll());
        }

        //
        // GET: /Role/Details/5

        public ActionResult Details(int id)
        {
            if (!Access.HasAccess(10))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Capital", route);
            }
            Role theRole = new Role();
            theRole = theRole.GetById(id);
            
            return View(theRole);
        }

        //
        // GET: /Role/Create

        public ActionResult Create()
        {
            if (!Access.HasAccess(9))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Capital", route);
            }
            RoleNew theRole = new RoleNew();
            return View(theRole);
        } 

        //
        // POST: /Role/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (!Access.HasAccess(9))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Capital", route);
            }
            try
            {
                // TODO: Add insert logic here
                Role theRole = new Role();                
                theRole.Name = collection["Name"];
                string [] arrayActionID = collection["Actions"].Split(',');
                                
                foreach (string str in arrayActionID)
                {
                    int actionID = Convert.ToInt32(str);
                    HardX.Models.Action theAction = new HardX.Models.Action();
                    theAction = theAction.GetById(actionID);
                    theRole.Actions.Add(theAction);
                }

                string[] arrayUserID = collection["Users"].Split(',');

                foreach (string str in arrayUserID)
                {
                    int userID = Convert.ToInt32(str);
                    HardX.Models.User theUser = new HardX.Models.User();
                    theUser = theUser.GetById(userID);
                    theRole.Users.Add(theUser);
                }


                theRole.Save(theRole);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Role/Edit/5
 
        public ActionResult Edit(int id)
        {
            if (!Access.HasAccess(11))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Capital", route);
            }
            Role theRole = new Role();
            theRole = theRole.GetById(id);

            return View(theRole);
        }

        //
        // POST: /Role/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (!Access.HasAccess(11))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Capital", route);
            }
            try
            {
                // TODO: Add update logic here
                Role theRole = new Role();
                theRole = theRole.GetById(id);
                theRole.Name = collection["Name"];
                theRole.Update(theRole);
                string[] arrayActionID = collection["Actions"].Split(',');

                theRole.ClearActions();

                foreach (string str in arrayActionID)
                {
                    int actionID = Convert.ToInt32(str);
                    HardX.Models.Action theAction = new HardX.Models.Action();
                    theAction = theAction.GetById(actionID);
                    theRole.Actions.Add(theAction);
                }
                theRole.Update(theRole);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Role/Delete/5
 
        public ActionResult Delete(int id)
        {
            if (!Access.HasAccess(12))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Capital", route);
            }
            Role theRole = new Role();
            theRole = theRole.GetById(id);
            theRole.Delete(theRole);
            return RedirectToAction("Index");
        }

        //
        // POST: /Role/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (!Access.HasAccess(12))
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
