using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;

namespace HardX.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/

        public ActionResult Index()
        {
            Store theStore = new Store();
            List<Store> theListStore = new List<Store>();
            theListStore = (List<Store>)theStore.GetAll();

            return View(theListStore);
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Store/Create

        public ActionResult Create()
        {
            NewStore model = new NewStore();


            return View(model);
        } 

        //
        // POST: /Store/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {

                Store model = new Store();

                model.Name = collection["Name"];
               
                model.Save(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        
        //
        // GET: /Store/Edit/5
 
        public ActionResult Edit(int id)
        {
            Store model = new Store();
            model = model.GetById(id);
            return View(model);
        }

        //
        // POST: /Store/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {

                Store model = new Store();

                model = model.GetById(id);

                model.Name = collection["Name"];
                
                model.Update(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        //
        // GET: /Store/Matmodels/5

        public ActionResult Matmodels(int id)
        {
            Material model = new Material();
            model.Store = (new Store()).GetById(id);
            ViewBag.Materials = (new Store()).GetById(id).Materials;
            return View(model);
        }

        //
        // POST: /Store/Matmodels/5

        [HttpPost]
        public ActionResult Matmodels(int id, FormCollection collection)
        {
            try
            {
                Material model = new Material();
                
                int count = 0;
                try
                {
                    count = Convert.ToInt32(collection["Count"]);
                }
                catch
                {
                }

                for (int i = 0; i < count; i++)
                {
                    model.Store = (new Store()).GetById(id);
                    model.Matmodel = (new Matmodel()).GetById(Convert.ToInt32(collection["MatmodelID"]));
                    model.Save(model);
                }
                ViewBag.Materials = model.Store.Materials;                        

                return View(model);
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
                Store model = new Store();
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
