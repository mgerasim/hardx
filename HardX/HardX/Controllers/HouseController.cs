using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;

namespace HardX.Controllers
{
    public class HouseController : Controller
    {
        //
        // GET: /House/

        public ActionResult Index()
        {
            House model = new House();
            List<House> theListModel = new List<House>();
            theListModel = (List<House>)model.GetAll();

            return View(theListModel);
        }

        //
        // GET: /House/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /House/Create

        public ActionResult Create()
        {
            HouseNew model = new HouseNew();
            return View(model);
        }

        //
        // POST: /House/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                House model = new House();
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
        // GET: /House/Edit/5

        public ActionResult Edit(int id)
        {
            House model = new House();
            model = model.GetById(id);
            return View(model);
        }

        //
        // POST: /House/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                House model = new House();
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
        // GET: /House/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /House/Delete/5

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
