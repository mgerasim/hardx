using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;

namespace HardX.Controllers
{
    public class TownController : Controller
    {
        //
        // GET: /Town/

        public ActionResult Index()
        {
            Town model = new Town();
            List<Town> theListModel = new List<Town>();
            theListModel = (List<Town>)model.GetAll();

            return View(theListModel);
        }

        //
        // GET: /Town/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Town/Create

        public ActionResult Create()
        {
            TownNew model = new TownNew();
            return View(model);
        } 

        //
        // POST: /Town/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Town model = new Town();
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
        // GET: /Town/Edit/5
 
        public ActionResult Edit(int id)
        {
            Town model = new Town();
            model = model.GetById(id);
            return View(model);
        }

        //
        // POST: /Town/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Town model = new Town();
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
        // GET: /Town/Delete/5
 
        public ActionResult Delete(int id)
        {
            Town model = new Town();
            model = model.GetById(id);
            model.Delete(model);

            return RedirectToAction("Index");
        }

        //
        // POST: /Town/Delete/5

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
