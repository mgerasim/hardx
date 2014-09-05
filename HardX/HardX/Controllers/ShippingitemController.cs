using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;

namespace HardX.Controllers
{
    public class ShippingitemController : Controller
    {
        //
        // GET: /Shippingitems/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Shippingitems/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Shippingitems/Create

        public ActionResult CreateAjaxMat(int shipping_id, int matmodel_id, int count)
        {
            Shippingitem theItem = new Shippingitem();
            theItem.Shipping = (new Shipping()).GetById(shipping_id);
            theItem.Matmodel = (new Matmodel()).GetById(matmodel_id);
            theItem.Count = count;
            theItem.Save(theItem);
            return View(theItem);
        }

        public ActionResult CreateAjaxDev(int shipping_id, int devmodel_id, int count)
        {
            Shippingitem theItem = new Shippingitem();
            theItem.Shipping = (new Shipping()).GetById(shipping_id);
            theItem.Devmodel = (new Devmodel()).GetById(devmodel_id);
            theItem.Count = count;
            theItem.Save(theItem);
            return View(theItem);
        }

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Shippingitems/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Shippingitems/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Shippingitems/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Shippingitems/Delete/5
 
        public ActionResult Delete(int id)
        {

            Shippingitem model = new Shippingitem();
            model = model.GetById(id);
            model.Delete(model);

            return View(model);
        }

        //
        // POST: /Shippingitems/Delete/5

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
