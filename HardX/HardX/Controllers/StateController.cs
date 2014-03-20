using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;

namespace HardX.Controllers
{
    public class StateController : Controller
    {
        //
        // GET: /State/

        public ActionResult Index()
        {
            State model = new State();
            List<State> theListModel = new List<State>();
            theListModel = (List<State>)model.GetAll();

            return View(theListModel);
        }

        //
        // GET: /State/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /State/Create

        public ActionResult Create()
        {
            StateNew model = new StateNew();
            return View(model);
        } 

        //
        // POST: /State/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                State model = new State();
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
        // GET: /State/Edit/5
 
        public ActionResult Edit(int id)
        {
            State model = new State();
            model = model.GetById(id);
            return View(model);
        }

        //
        // POST: /State/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                State model = new State();
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
        // GET: /State/Delete/5
 
        public ActionResult Delete(int id)
        {
            State model = new State();
            model = model.GetById(id);
            model.Delete(model);

            return RedirectToAction("Index");
        }

        //
        // POST: /State/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
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
