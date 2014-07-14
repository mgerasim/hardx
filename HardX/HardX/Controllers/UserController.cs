using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;
using HardX.Utils;

namespace HardX.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            
            if (!Access.HasAccess(1))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            
            List<User> theListUser = new List<User>();
            User theUser = new User();
            theListUser = (List<User>)theUser.GetAll();

            return View(theListUser);
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id)
        {
            
            if (!Access.HasAccess(4))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            
            User theUser = new User();            
            theUser = theUser.GetById(id);
            return View(theUser);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {            
            if (!Access.HasAccess(2))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            
            UserNew theUser = new UserNew();
            return View(theUser);
        } 

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            
            if (!Access.HasAccess(2))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            
            try
            {
                // TODO: Add insert logic here
                User theUser = new User();                
                theUser.Login = collection["Login"];
                theUser.Name = collection["Name"];
                Branche theBranche = new Branche();
                theUser.Branche = theBranche.GetById(Convert.ToInt32(collection["Branche.ID"]));
                
                string[] arrayRoleID = collection["Roles"].Split(',');

                foreach (string str in arrayRoleID)
                {
                    int roleID = Convert.ToInt32(str);
                    HardX.Models.Role theRole2 = new HardX.Models.Role();
                    theRole2 = theRole2.GetById(roleID);
                    theUser.Roles.Add(theRole2);
                }

                theUser.Save(theUser);
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
        // GET: /User/Edit/5
 
        public ActionResult Edit(int id)
        {
            
            if (!Access.HasAccess(3))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            
            User theUser = new User();
            theUser = theUser.GetById(id);
            return View(theUser);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            
            if (!Access.HasAccess(3))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            
            try
            {
                // TODO: Add update logic here
                User theUser = new User();
                theUser = theUser.GetById(id);
                theUser.Login = collection["Login"];
                theUser.Name  = collection["Name"];
                Branche theBranche = new Branche();
                theUser.Branche = theBranche.GetById( Convert.ToInt32(collection["Branche.ID"]));
                
                string[] arrayRoleID = collection["Roles"].Split(',');

                theUser.ClearRoles();

                foreach (string str in arrayRoleID)
                {
                    int roleID = Convert.ToInt32(str);
                    HardX.Models.Role theRole2 = new HardX.Models.Role();
                    theRole2 = theRole2.GetById(roleID);
                    theUser.Roles.Add(theRole2);
                }


                theUser.Update(theUser);
                
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
        // GET: /User/Delete/5
 
        public ActionResult Delete(int id)
        {
            
            if (!Access.HasAccess(5))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }

            User theUser = new User();
            theUser = theUser.GetById(id);
            theUser.Delete(theUser);
            return RedirectToAction("Index");
        }

        //
        // POST: /User/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (!Access.HasAccess(5))
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
            catch (Exception ex)
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", ex.Message);
                return RedirectToAction("Error", "Home", route);
            }
        }
    }
}
