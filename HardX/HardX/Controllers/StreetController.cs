using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;

namespace HardX.Controllers
{
    public class StreetController : Controller
    {
        //
        // GET: /Street/

        public ActionResult Index()
        {
            Street model = new Street();
            List<Street> theListModel = new List<Street>();
            theListModel = (List<Street>)model.GetAll();

            return View(theListModel);
        }

        //
        // GET: /Street/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Street/Create

        public ActionResult Create()
        {
            StreetNew model = new StreetNew();
            return View(model);
        } 

        //
        // POST: /Street/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Street model = new Street();
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
        // GET: /Street/Edit/5
 
        public ActionResult Edit(int id)
        {
            Street model = new Street();
            model = model.GetById(id);
            return View(model);
        }

        //
        // POST: /Street/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Street model = new Street();
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
        // GET: /Street/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Street/Delete/5

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
