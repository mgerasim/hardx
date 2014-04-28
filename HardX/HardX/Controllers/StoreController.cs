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
                
                if (collection["User.Id"] != "")
                {
                    model.User = (new User()).GetById(Convert.ToInt32(collection["User.Id"]));
                }

                if (collection["Area.Id"] != "")
                {
                    model.Area = (new Area()).GetById(Convert.ToInt32(collection["Area.Id"]));
                }
               
                model.Save(model);

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

                if (collection["User.Id"] != "")
                {
                    model.User = (new User()).GetById(Convert.ToInt32(collection["User.Id"]));
                }

                if (collection["Area.Id"] != "")
                {
                    model.Area = (new Area()).GetById(Convert.ToInt32(collection["Area.Id"]));
                }
                
                model.Update(model);

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
        // GET: /Store/Matmodels/5

        public ActionResult Materials(int id)
        {
            Material model = new Material();
            model.Store = (new Store()).GetById(id);
            return View(model);
        }

        //
        // POST: /Store/Matmodels/5

        [HttpPost]
        public ActionResult Materials(int id, FormCollection collection)
        {
            Material model = new Material();
            try
            {
                model.Store = (new Store()).GetById(id);

                if (collection["fAdded"]=="on")
                {
                    Material modelAdded = new Material();
                    modelAdded.Store = (new Store()).GetById(id);
                    modelAdded.Matmodel = (new Matmodel()).GetById(Convert.ToInt32(collection["MatmodelID"]));
                    modelAdded.StatusID = 21; /*добавлен*/
                    modelAdded.Save(modelAdded);
                }
                
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
                    model.Matmodel = (new Matmodel()).GetById(Convert.ToInt32(collection["MatmodelID"]));
                    model.StatusID = 1; /*остаток*/
                    model.Save(model);
                }                
                ViewBag.Materials = model.Store.Materials;

                int count_issued = 0;
                try
                {
                    count_issued = Convert.ToInt32(collection["CountIssued"]) + 1;
                }
                catch
                {
                }

                List<Material> models = new List<Material>();
                string s = "REPOSITORY_ID = " + id.ToString() +
                        " AND mat_model_id = " + collection["MatmodelID"] +
                        " AND status_id = 1 " +
                        " AND rownum < " + count_issued.ToString();
                models = (List<Material>)model.GetAll(s);

                foreach(Material item in models)
                {
                    item.StatusID = 2;
                    item.Update(item);
                }
                                                   
                int count_marriage = 0;    
                try
                {
                    count_marriage = Convert.ToInt32(collection["CountMarriage"]) + 1;
                }
                catch
                {
                }
                models.Clear();
                s = "REPOSITORY_ID = " + id.ToString() +
                        " AND mat_model_id = " + collection["MatmodelID"] +
                        " AND status_id = 1 " +
                        " AND rownum < " + count_marriage.ToString();
                models = (List<Material>)model.GetAll(s);        
                foreach (Material item in models)
                {
                    item.StatusID = 3;
                    item.Update(item);
                }
                
                //delete
                int count_delete = 0;
                try
                {
                    count_delete = Convert.ToInt32(collection["CountDelete"]) + 1;
                }
                catch
                {
                }
                models.Clear();
                s = "REPOSITORY_ID = " + id.ToString() +
                        " AND mat_model_id = " + collection["MatmodelID"] +
                        " AND status_id = 1 " +
                        " AND rownum < " + count_delete.ToString();
                models = (List<Material>)model.GetAll(s);
                foreach (Material item in models)
                {
                    item.Delete(item);
                }
                                     
                return View(model);
            }
            catch (Exception ex)
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", ex.Message);
                return RedirectToAction("Error", "Home", route);
            }
        }

        //
        // GET: /Store/Matmodels/5

        public ActionResult issue(int repository_id, int matmodel_id)
        {

            ViewBag.repository_id = repository_id;
            ViewBag.matmodel_id = matmodel_id;

            return View();
        }

        //
        // POST: /Store/Matmodels/5

        [HttpPost]
        public ActionResult issue(int repository_id, int matmodel_id, FormCollection collection)
        {
            try
            {
                Material model = new Material();

              

                return View(model);
            }
            catch (Exception ex)
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", ex.Message);
                return RedirectToAction("Error", "Home", route);
            }
        }

        public ActionResult marriage(int repository_id, int matmodel_id)
        {
            Material model = new Material();
            return View(model);
        }

        //
        // POST: /Store/Matmodels/5

        [HttpPost]
        public ActionResult marriage(int repository_id, int matmodel_id, FormCollection collection)
        {
            try
            {
                Material model = new Material();


                return View(model);
            }
            catch (Exception ex)
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", ex.Message);
                return RedirectToAction("Error", "Home", route);
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
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", ex.Message);
                return RedirectToAction("Error", "Home", route);
            }
        }

        //
        // GET: /Store/Report/5

        public ActionResult Report(int id)
        {
            Material model = new Material();
            model.Store = (new Store()).GetById(id);
            return View(model);
        }

        //
        // POST: /Store/Report/5

        [HttpPost]
        public ActionResult Report(int id, FormCollection collection)
        {
            Material model = new Material();
            try
            {
                model.Store = (new Store()).GetById(id);

                string listStr = collection["MaterialUchetSelections"];


                return RedirectToAction("Excel",  new { id = id, collection = listStr});
            }
            catch (Exception ex)
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", ex.Message);
                return RedirectToAction("Error", "Home", route);
            }
        }
        //
        // GET: /Store/Report/5

        public ActionResult Excel(int id, string collection)
        {
            MaterialUchet model = new MaterialUchet();
            List<MaterialUchet> theList = new List<MaterialUchet>();
            theList = (List<MaterialUchet>)model.GetAll("repository_id = " + id.ToString() + " AND id in (" + collection + ")", "VENDOR_NAME");
            
            Response.AddHeader("Content-Type", "application/vnd.ms-excel");
                      
                        

            return View(theList);
        }
    }
}
