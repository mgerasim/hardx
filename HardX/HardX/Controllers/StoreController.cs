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

                if (collection["User2.Id"] != "")
                {
                    model.User2 = (new User()).GetById(Convert.ToInt32(collection["User2.Id"]));
                }

                if (collection["Room.ID"] != "")
                {
                    model.Room = (new Room()).GetById(Convert.ToInt32(collection["Room.ID"]));
                }

                if (collection["Areas"] != null)
                {
                    string[] arrayAreaIDs = collection["Areas"].Split(',');
                    foreach (string str in arrayAreaIDs)
                    {
                        int areaID = Convert.ToInt32(str);
                        HardX.Models.Area theArea = new HardX.Models.Area();
                        theArea = theArea.GetById(areaID);
                        model.Areas.Add(theArea);
                    }
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

                if (collection["User2.Id"] != "")
                {
                    model.User2 = (new User()).GetById(Convert.ToInt32(collection["User2.Id"]));
                }

                if (collection["Room.ID"] != "")
                {
                    model.Room = (new Room()).GetById(Convert.ToInt32(collection["Room.ID"]));
                }

                if (collection["Areas"] != null)
                {
                    string[] arrayAreaIDs = collection["Areas"].Split(',');
                    model.ClearAreas();
                    foreach (string str in arrayAreaIDs)
                    {
                        int areaID = Convert.ToInt32(str);
                        HardX.Models.Area theArea = new HardX.Models.Area();
                        theArea = theArea.GetById(areaID);
                        model.Areas.Add(theArea);
                    }
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

                StoreMatDetail theMatDetail = new StoreMatDetail();
                theMatDetail.Matmodel = (new Matmodel()).GetById(Convert.ToInt32(collection["MatmodelID"]));
                theMatDetail.Store = (new Store()).GetById(id);
                theMatDetail.Save(theMatDetail);

                     
                return View(model);
            }
            catch (Exception ex)
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", ex.Message);
                return RedirectToAction("Error", "Home", route);
            }
                 
        }

        public ActionResult Devices(int id)
        {
            Device theDev = new Device();            
            theDev.Store = (new Store()).GetById(id);
            return View(theDev);
        }

        [HttpPost]
        public ActionResult Devices(int id, FormCollection collection)
        {
            Device theDev = new Device();
            try
            {
                theDev.Store = (new Store()).GetById(id);

                StoreDevDetail theDevDetail = new StoreDevDetail();
                theDevDetail.Devmodel = (new Devmodel()).GetById(Convert.ToInt32(collection["Devmodel.ID"]));
                theDevDetail.Store = (new Store()).GetById(id);
                theDevDetail.Save(theDevDetail);
                
                return View(theDev);
            }
            catch (Exception ex)
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", ex.Message);
                return RedirectToAction("Error", "Home", route);
            }

        }

        public ActionResult MaterialsGet(int repository_id, int matmodel_id, int count_delta)
        {
            Material model = new Material();
            model.Store = (new Store()).GetById(repository_id);
            
            for (int i = 0; i < count_delta; i++)
            {
                model.Matmodel = (new Matmodel()).GetById(matmodel_id);
                model.StatusID = 1;
                model.Save(model);
            }
            
            return View();
        }

        public ActionResult MaterialsDel(int repository_id, int matmodel_id, int count_delta)
        {
            Material model = new Material();
            model.Store = (new Store()).GetById(repository_id);
            
            List<Material> models = new List<Material>();
            string s = "REPOSITORY_ID = " + repository_id.ToString() +
                        " AND mat_model_id = " + matmodel_id.ToString() +
                        " AND status_id = 1 " +
                        " AND rownum < " + (count_delta + 1).ToString();
            models = (List<Material>)model.GetAll(s);
            foreach (Material item in models)
            {
                item.Delete(item);
            }
            
            return View();
        }


        public ActionResult DevicesGet(int repository_id, int devmodel_id, int count_delta)
        {
            Device model = new Device();
            model.Store = (new Store()).GetById(repository_id);
            for (int i = 0; i < count_delta; i++)
            {
                model.Devmodel = (new Devmodel()).GetById(devmodel_id);
                model.StatusID = 1;
                model.Save(model);
            }
            return View();
        }

        public ActionResult DevicesDel(int repository_id, int devmodel_id, int count_delta)
        {
            Device model = new Device();
            model.Store = (new Store()).GetById(repository_id);

            List<Device> models = new List<Device>();
            string s = "REPOSITORY_ID = " + repository_id.ToString() +
                        " AND dev_model_id = " + devmodel_id.ToString() +
                        " AND status_id = 1 " +
                        " AND rownum < " + (count_delta + 1).ToString();
            models = (List<Device>)model.GetAll(s);
            foreach (Device item in models)
            {
                item.Delete(item);
            }

            return View();
        }

        public ActionResult DevicesIssued(int repository_id, int devmodel_id, int count_delta)
        {
            Device model = new Device();

            List<Device> models = new List<Device>();
            string s = "REPOSITORY_ID = " + repository_id.ToString() +
                        " AND dev_model_id = " + devmodel_id.ToString() +
                        " AND status_id = 1 " +
                        " AND rownum < " + (count_delta + 1).ToString();
            models = (List<Device>)model.GetAll(s);

            model.Store = (new Store()).GetById(repository_id);
            foreach (Device item in models)
            {
                item.StatusID = 2;
                item.Updated_At = DateTime.Now;
                item.Update(item);
            }
            return View();
        }

        public ActionResult DevicesMarriage(int repository_id, int devmodel_id, int count_delta)
        {
            Device model = new Device();

            List<Device> models = new List<Device>();
            string s = "REPOSITORY_ID = " + repository_id.ToString() +
                        " AND dev_model_id = " + devmodel_id.ToString() +
                        " AND status_id = 1 " +
                        " AND rownum < " + (count_delta + 1).ToString();
            models = (List<Device>)model.GetAll(s);

            model.Store = (new Store()).GetById(repository_id);
            foreach (Device item in models)
            {
                item.StatusID = 3;
                item.Updated_At = DateTime.Now;
                item.Update(item);
            }
            return View();
        }

        public ActionResult DevicesIssuedDel(int repository_id, int devmodel_id, int count_delta)
        {
            Device model = new Device();

            List<Device> models = new List<Device>();
            string s = "REPOSITORY_ID = " + repository_id.ToString() +
                        " AND dev_model_id = " + devmodel_id.ToString() +
                        " AND status_id = 2 " +
                        " AND rownum < " + (count_delta + 1).ToString();
            models = (List<Device>)model.GetAll(s);

            model.Store = (new Store()).GetById(repository_id);
            foreach (Device item in models)
            {
                item.StatusID = 1;
                item.Updated_At = DateTime.Now;
                item.Update(item);
            }
            return View();
        }

        public ActionResult DevicesMarriageDel(int repository_id, int devmodel_id, int count_delta)
        {
            Device model = new Device();

            List<Device> models = new List<Device>();
            string s = "REPOSITORY_ID = " + repository_id.ToString() +
                        " AND dev_model_id = " + devmodel_id.ToString() +
                        " AND status_id = 3 " +
                        " AND rownum < " + (count_delta + 1).ToString();
            models = (List<Device>)model.GetAll(s);

            model.Store = (new Store()).GetById(repository_id);
            foreach (Device item in models)
            {
                item.StatusID = 1;
                item.Updated_At = DateTime.Now;
                item.Update(item);
            }
            return View();
        }


        public ActionResult MaterialsMarriage(int repository_id, int matmodel_id, int count_delta)
        {
            Material model = new Material();

            List<Material> models = new List<Material>();
            string s = "REPOSITORY_ID = " + repository_id.ToString() +
                        " AND mat_model_id = " + matmodel_id.ToString() +
                        " AND status_id = 1 " +
                        " AND rownum < " + (count_delta + 1).ToString();
            models = (List<Material>)model.GetAll(s);     

            model.Store = (new Store()).GetById(repository_id);
            foreach (Material item in models)
            {
                item.StatusID = 3;
                item.Updated_At = DateTime.Now;
                item.Update(item);
            }
            return View();
        }

        public ActionResult MaterialsIssued(int repository_id, int matmodel_id, int count_delta)
        {
            Material model = new Material();

            List<Material> models = new List<Material>();
            string s = "REPOSITORY_ID = " + repository_id.ToString() +
                        " AND mat_model_id = " + matmodel_id.ToString() +
                        " AND status_id = 1 " +
                        " AND rownum < " + (count_delta + 1).ToString();
            models = (List<Material>)model.GetAll(s);

            model.Store = (new Store()).GetById(repository_id);
            foreach (Material item in models)
            {
                item.StatusID = 2;
                item.Updated_At = DateTime.Now;
                item.Update(item);
            }
            return View();
        }

        public ActionResult MaterialsIssuedDel(int repository_id, int matmodel_id, int count_delta)
        {
            Material model = new Material();

            List<Material> models = new List<Material>();
            string s = "REPOSITORY_ID = " + repository_id.ToString() +
                        " AND mat_model_id = " + matmodel_id.ToString() +
                        " AND status_id = 2 " +
                        " AND rownum < " + (count_delta + 1).ToString();
            models = (List<Material>)model.GetAll(s);

            model.Store = (new Store()).GetById(repository_id);
            foreach (Material item in models)
            {
                item.StatusID = 1;
                item.Update(item);
            }
            return View();
        }

        public ActionResult MaterialsMarriageDel(int repository_id, int matmodel_id, int count_delta)
        {
            Material model = new Material();

            List<Material> models = new List<Material>();
            string s = "REPOSITORY_ID = " + repository_id.ToString() +
                        " AND mat_model_id = " + matmodel_id.ToString() +
                        " AND status_id = 3 " +
                        " AND rownum < " + (count_delta + 1).ToString();
            models = (List<Material>)model.GetAll(s);

            model.Store = (new Store()).GetById(repository_id);
            foreach (Material item in models)
            {
                item.StatusID = 1;
                item.Update(item);
            }
            return View();
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

        public ActionResult DeleteMatDetail(int ID)
        {
            try
            {
                StoreMatDetail theMD = new StoreMatDetail();
                theMD = theMD.GetById(ID);              
                
                theMD.Delete(theMD);

                return RedirectToAction("Materials", new  { id = theMD.Store.ID });
            }
            catch (Exception ex)
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", ex.Message);
                return RedirectToAction("Error", "Home", route);
            }
        }

        public ActionResult DeleteDevDetail(int ID)
        {
            try
            {
                StoreDevDetail theDD = new StoreDevDetail();
                theDD = theDD.GetById(ID);

                theDD.Delete(theDD);

                return RedirectToAction("Devices", new { id = theDD.Store.ID });
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
            string filename = "Отчёт-Склад-" + (new Store()).GetById(id).Name + "_" + DateTime.Now.ToString("yyyy-MM-dd");
            filename = filename.Replace(' ', '-');
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.AddHeader("Content-Type", "application/vnd.ms-excel");
            return View(theList);
        }

        public ActionResult ReportMaterialsGet(int repository_id, string report_bgn, string report_end)
        {
            string strWhere = "repository_id="+repository_id.ToString();
            strWhere += " AND to_date('" + report_bgn + "', 'DD.MM.YYYY') <= updated_at";
            strWhere += " AND to_date('" + report_end + "', 'DD.MM.YYYY') >= updated_at";
            Material theModel = new Material();
            List<Material> theList = (List<Material>)theModel.GetAll(strWhere);
            foreach (var g in theList.GroupBy(x => x.Matmodel.ID))
            {
                int i = g.Count();
            }


                /*
            MaterialUchet model = new MaterialUchet();
            List<MaterialUchet> theList = new List<MaterialUchet>();
            theList = (List<MaterialUchet>)model.GetAll("repository_id = " + repository_id.ToString(), "VENDOR_NAME");
                 * */
            string filename = "Отчёт-Склад-" + (new Store()).GetById(repository_id).Name + "_" + DateTime.Now.ToString("yyyy-MM-dd")+".xls";
            filename = filename.Replace(' ', '-');
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.AddHeader("Content-Type", "application/vnd.ms-excel");
            Response.AddHeader("Set-Cookie", "fileDownload=true");
            Response.AddHeader("Cache-Control", "max-age=60, must-revalidate");
            return View(theList);
        }
    }
}
