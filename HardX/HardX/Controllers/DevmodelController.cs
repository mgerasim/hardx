using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;
using HardX.ViewModels;

namespace HardX.Controllers
{
    public class DevmodelController : Controller
    {
        //
        // GET: /Devmodel/

        public ActionResult Index()
        {
            List<Devmodel> theListDevmodel = new List<Devmodel>();
            Devmodel theDevmodel = new Devmodel();
            theListDevmodel = (List<Devmodel>)theDevmodel.GetAll();

            return View(theListDevmodel);
        }


        public ActionResult Compatibility(int ID)
        {
            Devmodel model = new Devmodel();
            model = model.GetById(ID);

            return View(new DevmodelInput()
                {
                    TheDevmodel = model,
                    MatmodelSelections = (List<Matmodel>)(new Matmodel()).GetAll(),
                    SelectedMatmodel = model.Matmodels.Select(x => x.ID).ToList()
                });
        }

        [HttpPost]
        public ActionResult Compatibility(int ID, FormCollection collection)
        {
            Devmodel model = new Devmodel();
            model = model.GetById(ID);

            string IDs = collection["MatmodelSelections"];

            model.Matmodels.Clear();
            model.Update(model);

            foreach (string item in IDs.Split(','))
            {
                model.Matmodels.Add((new Matmodel()).GetById(Convert.ToInt32(item)));
            }

            model.Update(model);

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            NewDevmodel model = new NewDevmodel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try{
                Devmodel model = new Devmodel();
                model.Name = collection["Name"];
                model.Printspeed = Convert.ToInt32(collection["Printspeed"]);
                model.Typedev = (new Typedev()).GetById( Convert.ToInt32(collection["TypedevID"]) );
                model.Vendor =  (new Vendor()).GetById( Convert.ToInt32(collection["VendorID"]) );
                model.Capacity = Convert.ToInt32(collection["Capacity"]);

                model.Save(model);

                return RedirectToAction("Index");
             }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public ActionResult Edit(int ID)
        {
            Devmodel model = new Devmodel();
            model = model.GetById(ID);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int ID, FormCollection collection)
        {
            try
            {
                Devmodel model = new Devmodel();
                model = model.GetById(ID);

                model.Name = collection["Name"];
                model.Printspeed = Convert.ToInt32(collection["Printspeed"]);
                model.Typedev = (new Typedev()).GetById(Convert.ToInt32(collection["TypedevID"]));
                model.Vendor = (new Vendor()).GetById(Convert.ToInt32(collection["VendorID"]));
                model.Capacity = Convert.ToInt32(collection["Capacity"]);

                model.Update(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public ActionResult Delete(int ID)
        {
            try
            {
                Devmodel model = new Devmodel();
                model = model.GetById(ID);
                                
                model.Delete(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

    }
}
