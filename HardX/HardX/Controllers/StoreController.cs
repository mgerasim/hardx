using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;
using HardX.Utils;

namespace HardX.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/

        public ActionResult Index()
        {
            if (!Access.HasAccess(66))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Store theStore = new Store();
            List<Store> theListStore = new List<Store>();
            theListStore = (List<Store>)theStore.GetAll();

            return View(theListStore);
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(int id)
        {
            if (!Access.HasAccess(69))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            return View();
        }

        //
        // GET: /Store/Create

        public ActionResult Create()
        {
            if (!Access.HasAccess(67))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            NewStore model = new NewStore();
            return View(model);
        } 

        //
        // POST: /Store/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (!Access.HasAccess(67))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
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
            if (!Access.HasAccess(68))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Store model = new Store();
            model = model.GetById(id);
            return View(model);
        }

        //
        // POST: /Store/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (!Access.HasAccess(68))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
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
            if (!Access.HasAccess(66))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Material theModel = new Material();
            List<Material> theList = (List<Material>)theModel.GetAll("REPOSITORY_ID="+id.ToString());
            
            Store theStore = new Store();
            theStore = theStore.GetById(id);
            ViewBag.theStore = theStore;


            ViewBag.Mathistory = ((List<Mathistory>)(new Mathistory()).GetAll());
            ViewBag.Materials = (new Material()).GetAll();
            
            ViewBag.Stores = (new Store()).GetAll();

            ViewBag.Matmodels = (new Matmodel()).GetAll();
                        
            return View(theList);
        }

        //
        // POST: /Store/Matmodels/5

        [HttpPost]
        public ActionResult Materials(int id, FormCollection collection)
        {
            try
            {
                if (!Access.HasAccess(66))
                {
                    System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                    route.Add("err", "Нет доступа!");
                    return RedirectToAction("Error", "Home", route);
                }
                
                this.MaterialsGet(id, Convert.ToInt32(collection["[0].Matmodel.ID"]), Convert.ToInt32(collection["count_added"]));
                
                return this.Materials(id);
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
            if (!Access.HasAccess(66))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Device theModel = new Device();
            List<Device> theList = (List<Device>)theModel.GetAll("REPOSITORY_ID=" + id.ToString());

            Store theStore = new Store();
            theStore = theStore.GetById(id);
            ViewBag.theStore = theStore;
                        
            ViewBag.Stores = (new Store()).GetAll();
            ViewBag.Devhistories = (List<Devhistory>)(new Devhistory()).GetAll("STORE_ID = " + id.ToString());
            ViewBag.Devmodels = (List<Devmodel>)(new Devmodel()).GetAll();

            return View(theList);
        }

        [HttpPost]
        public ActionResult Devices(int id, FormCollection collection)
        {
            if (!Access.HasAccess(66))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            try
            {
                this.DevicesGet(id, Convert.ToInt32(collection["[0].Devmodel.ID"]), Convert.ToInt32(collection["count_added"]));
                return this.Devices(id);
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
                model.StatusID = (1);
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
        
        public ActionResult Delete(int ID)
        {
            if (!Access.HasAccess(70))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
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

                return RedirectToAction("Materials");
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
               
                return RedirectToAction("Devices");
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

            Store theStore = new Store();
            theStore = theStore.GetById(repository_id);
            ViewBag.theStore = theStore;

            ViewBag.Mathistory = ((List<Mathistory>)(new Mathistory()).GetAll());
            ViewBag.Materials = (new Material()).GetAll();

            string filename = "Отчёт-Склад-Материалы-" + (new Store()).GetById(repository_id).Name + "_" + DateTime.Now.ToString("yyyy-MM-dd")+".xls";
            filename = filename.Replace(' ', '-');
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.AddHeader("Content-Type", "application/ms-excel; charset=utf-8");
            Response.AddHeader("Set-Cookie", "fileDownload=true");
            Response.AddHeader("Cache-Control", "max-age=60, must-revalidate");
            
            return View(theList);
        }

        public ActionResult ReportDevicesGet(int repository_id, string report_bgn, string report_end)
        {
            string strWhere = "repository_id=" + repository_id.ToString();
            strWhere += " AND to_date('" + report_bgn + "', 'DD.MM.YYYY') <= updated_at";
            strWhere += " AND to_date('" + report_end + "', 'DD.MM.YYYY') >= updated_at";
            Device theModel = new Device();
            List<Device> theList = (List<Device>)theModel.GetAll(strWhere);

            Store theStore = new Store();
            theStore = theStore.GetById(repository_id);
            ViewBag.theStore = theStore;

            ViewBag.Devices = ((List<Devhistory>)(new Devhistory()).GetAll()).Where(x => x.StatusID == 2).Where(x => x.StoreID == repository_id);
            ViewBag.Devhistory = ((List<Devhistory>)(new Devhistory()).GetAll());            

            string filename = "Отчёт-Склад-Оборудование-" + (new Store()).GetById(repository_id).Name + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
            filename = filename.Replace(' ', '-');
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.AddHeader("Content-Type", "application/ms-excel; charset=utf-8");
            Response.AddHeader("Set-Cookie", "fileDownload=true");
            Response.AddHeader("Cache-Control", "max-age=60, must-revalidate");
            
            return View(theList);
        }
        public ActionResult ReportDevicesGetList(int repository_id, string report_bgn, string report_end)
        {
            string strWhere = "repository_id=" + repository_id.ToString();
            strWhere += " AND to_date('" + report_bgn + "', 'DD.MM.YYYY') <= updated_at";
            strWhere += " AND to_date('" + report_end + "', 'DD.MM.YYYY') >= updated_at";
            Device theModel = new Device();
            List<Device> theList = (List<Device>)theModel.GetAll(strWhere);
            
            Store theStore = new Store();
            theStore = theStore.GetById(repository_id);
            ViewBag.theStore = theStore;

            ViewBag.Devices = ((List<Devhistory>)(new Devhistory()).GetAll()).Where(x => x.StatusID == 2).Where(x => x.StoreID == repository_id);
            ViewBag.Devhistory = ((List<Devhistory>)(new Devhistory()).GetAll());
            ViewBag.Stores = ((List<Store>)(new Store()).GetAll());

            string filename = "Отчёт-Склад-Оборудование-" + (new Store()).GetById(repository_id).Name + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
            filename = filename.Replace(' ', '-');
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.AddHeader("Content-Type", "application/ms-excel; charset=utf-8");
            Response.AddHeader("Set-Cookie", "fileDownload=true");
            Response.AddHeader("Cache-Control", "max-age=60, must-revalidate");
            
            return View(theList);
        }
        public ActionResult ShowMaterials(int id, int MatmodelID)
        {
            if (!Access.HasAccess(66))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            ViewBag.StoreID = id;
            ViewBag.MatmodelID = MatmodelID;
            Matmodel theMatmodel = (new Matmodel()).GetById(MatmodelID);
            ViewBag.Matmodel = theMatmodel;
            ViewBag.Stores = (new Store()).GetAll();
            ViewBag.Devices = (new Device()).GetAll();
            ViewBag.Rooms = (new Room()).GetAll();
            ViewBag.Materials = (new Material()).GetAll("MAT_MODEL_ID="+ViewBag.MatmodelID) ;
            List<Material> theMaterials1 = (new Material()).GetAll("MAT_MODEL_ID=" + ViewBag.MatmodelID+" AND REPOSITORY_ID="+ ViewBag.StoreID+" AND STATUS_ID=1");                
            
            ViewBag.Materials1 = theMaterials1;
            ViewBag.Materials22 = ((List<Material>)ViewBag.Materials).Where(x => x.StatusID == 22).Where(x => x.Store.ID == ViewBag.StoreID);
            ViewBag.Materials3 = ((List<Material>)ViewBag.Materials).Where(x => x.StatusID == 3).Where(x => x.Store.ID == ViewBag.StoreID);            
            ViewBag.Mathistory = (new Mathistory()).GetAll("STORE_ID=" + ViewBag.StoreID + " AND STATUS_ID=2");           
            return View();
        }

        public ActionResult ShowDevices(int id, int DevmodelID)
        {
            if (!Access.HasAccess(66))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            ViewBag.StoreID = id;
            ViewBag.DevmodelID = DevmodelID;
            ViewBag.Stores = (new Store()).GetAll();
            ViewBag.Rooms = (new Room()).GetAll();
            ViewBag.Devices = (new Device()).GetAll("DEV_MODEL_ID="+ViewBag.DevmodelID) ;
            ViewBag.Devices1 = ((List<Device>) ViewBag.Devices).Where(x => x.StatusID==1 ).Where(x => x.Store.ID==ViewBag.StoreID);
            ViewBag.Devices22 = ((List<Device>)ViewBag.Devices).Where(x => x.StatusID == 22).Where(x => x.Store.ID == ViewBag.StoreID);
            ViewBag.Devices3 = ((List<Device>)ViewBag.Devices).Where(x => x.StatusID == 3).Where(x => x.Store.ID == ViewBag.StoreID);
            
            ViewBag.Devhistory = (new Devhistory()).GetAll("STORE_ID=" + ViewBag.StoreID + " AND STATUS_ID=2");
            
            return View();
        }
        public ActionResult MaterialsUpdateStatus(int material_id, int status_id)
        {
            Material model = new Material();
            model = model.GetById(material_id);
            model.StatusID = (status_id);
            model.Updated_At = DateTime.Now;
            model.Update(model);
            return View();
        }
        public ActionResult DevicesUpdateStatus(int device_id, int status_id)
        {
            Device model = new Device();
            model = model.GetById(device_id);
            model.StatusID = status_id;
            model.Updated_At = DateTime.Now;
            model.Update(model);
            return View();
        }

        public ActionResult MaterialsSetCauseOfMarriage(int material_id, string cause_of_marriage)
        {
            Material model = new Material();
            model = model.GetById(material_id);
            model.StatusID = 3;
            model.CauseOfMarriage = cause_of_marriage;
            model.Updated_At = DateTime.Now;
            model.Update(model);
            return View();
        }

        public ActionResult MaterialsSetSetup(int material_id, int device_id)
        {
            Material model = new Material();
            model = model.GetById(material_id);
            model.DeviceSetupID = device_id;
            model.Updated_At = DateTime.Now;
            model.StatusID = 22;
            model.Update(model);
            return View();
        }

        public ActionResult MaterialsSetIssue(int material_id, int store_id)
        {
            Material model = new Material();
            model = model.GetById(material_id);            
            model.Updated_At = DateTime.Now;
            model.StatusID = 2;
            model.Update(model);


            model.StatusID = 1;
            model.Store = (new Store()).GetById(store_id);            
            model.Update(model);

            return View();
        }
        public ActionResult DevicesSetCauseOfMarriage(int device_id, string cause_of_marriage)
        {
            Device model = new Device();
            model = model.GetById(device_id);
            model.StatusID = 3;
            model.CauseOfMarriage = cause_of_marriage;
            model.Updated_At = DateTime.Now;
            model.Update(model);
            return View();
        }
        public ActionResult DevicesSetSetup(int device_id, int room_id, string serial, string ipaddr, string host)
        {
            Device model = new Device();
            model = model.GetById(device_id);
            model.RoomSetupID = (room_id);
            model.StatusID = 22;
            model.Updated_At = DateTime.Now;
            model.IPAddr = ipaddr;
            model.Host = host;
            model.Serial = serial;
            model.Update(model);
            return View();
        }   
        
        public ActionResult DevicesSetIssue(int device_id, int store_id)
        {
            Device model = new Device();
            model = model.GetById(device_id);
            model.Updated_At = DateTime.Now;
            model.StatusID = (2);
            model.Update(model);

            model.StatusID = 1; 
            model.Store = (new Store()).GetById(store_id);            
            
            model.Update(model);

            return View();            
        }

        public ActionResult DevicesSaveSerial(int device_id, string serial)
        {
            Device model = new Device();
            model = model.GetById(device_id);            
            model.Serial = serial;
            model.Updated_At = DateTime.Now;
            model.Update(model);
            return View();
        }

        public ActionResult DevicesSaveIPAddr(int device_id, string ipaddr)
        {
            Device model = new Device();
            model = model.GetById(device_id);
            model.IPAddr = ipaddr;
            model.Updated_At = DateTime.Now;
            model.Update(model);
            return View();
        }

        public ActionResult DevicesSaveHost(int device_id, string host)
        {
            Device model = new Device();
            model = model.GetById(device_id);
            model.Host = host;
            model.Updated_At = DateTime.Now;
            model.Update(model);
            return View();
        }

        public ActionResult MaterialsIssued(int repository_id, int matmodel_id, int store_id, int count_delta)
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
                 item.Updated_At = DateTime.Now;
                 item.StatusID = 2;
                 item.Update(item);
                 item.StatusID = 1;
                 item.Store = (new Store()).GetById(store_id);
                 item.Update(item);
             }
             
             return View();
         }

        public ActionResult DevicesIssued(int repository_id, int devmodel_id, int store_id, int count_delta)
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
                item.Updated_At = DateTime.Now;
                item.StatusID = 2;
                item.Update(item);
                item.StatusID = 1;
                item.Store = (new Store()).GetById(store_id);
                item.Update(item);
            }

            return View();
        } 
    }
}

