using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;

namespace HardX.Controllers
{
    public class RegionController : Controller
    {
        //
        // GET: /Region/

        public ActionResult Index()
        {
            Region model = new Region();
            List<Region> theListModel = new List<Region>();
            theListModel = (List<Region>)model.GetAll();

            return View(theListModel);
        }

        //
        // GET: /Region/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Region/Create

        public ActionResult Create()
        {
            RegionNew model = new RegionNew();
            return View(model);
        } 

        //
        // POST: /Region/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Region model = new Region();
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
        // GET: /Region/Edit/5
 
        public ActionResult Edit(int id)
        {
            Region model = new Region();
            model = model.GetById(id);
            return View(model);
        }

        //
        // POST: /Region/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Region model = new Region();
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
        // GET: /Region/Delete/5
 
        public ActionResult Delete(int id)
        {
            Region model = new Region();
            model = model.GetById(id);
            model.Delete(model);

            return RedirectToAction("Index");
        }

        //
        // POST: /Region/Delete/5

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
