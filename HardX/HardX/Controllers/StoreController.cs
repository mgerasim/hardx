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
            Material theModel = new Material();
            List<Material> theList = (List<Material>)theModel.GetAll("REPOSITORY_ID="+id.ToString());
            
            Store theStore = new Store();
            theStore = theStore.GetById(id);
            ViewBag.theStore = theStore;


            ViewBag.Mathistory = ((List<Mathistory>)(new Mathistory()).GetAll());
            ViewBag.Materials = (new Material()).GetAll();
                        
            return View(theList);
        }

        //
        // POST: /Store/Matmodels/5

        [HttpPost]
        public ActionResult Materials(int id, FormCollection collection)
        {
            try
            {
                StoreMatDetail theMatDetail = new StoreMatDetail();
                theMatDetail.Matmodel = (new Matmodel()).GetById(Convert.ToInt32(collection["[0].MatmodelID"]));
                theMatDetail.Store = (new Store()).GetById(id);
                theMatDetail.Save(theMatDetail);


                

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
            Device theModel = new Device();
            List<Device> theList = (List<Device>)theModel.GetAll("REPOSITORY_ID=" + id.ToString());

            Store theStore = new Store();
            theStore = theStore.GetById(id);
            ViewBag.theStore = theStore;

            ViewBag.Devices = ((List<Devhistory>)(new Devhistory()).GetAll()).Where(x => x.StatusID == 2).Where(x => x.StoreID == id);
            ViewBag.Devhistory = ((List<Devhistory>)(new Devhistory()).GetAll());

            return View(theList);
        }

        [HttpPost]
        public ActionResult Devices(int id, FormCollection collection)
        {
            try
            {
                StoreDevDetail theDevDetail = new StoreDevDetail();
                theDevDetail.Devmodel = (new Devmodel()).GetById(Convert.ToInt32(collection["[0].Devmodel.ID"]));
                theDevDetail.Store = (new Store()).GetById(id);
                theDevDetail.Save(theDevDetail);
                
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

        public ActionResult DevicesSetup(int repository_id, int devmodel_id, int count_delta)
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
                item.StatusID = 22;
                item.Updated_At = DateTime.Now;
                item.Update(item);
            }
            return View();
        }

        public ActionResult DevicesSetupDel(int repository_id, int devmodel_id, int count_delta)
        {
            Device model = new Device();

            List<Device> models = new List<Device>();
            string s = "REPOSITORY_ID = " + repository_id.ToString() +
                        " AND dev_model_id = " + devmodel_id.ToString() +
                        " AND status_id = 22 " +
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

        public ActionResult MaterialsSetup(int repository_id, int matmodel_id, int count_delta)
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
                item.StatusID = 22;
                item.Updated_At = DateTime.Now;
                item.Update(item);
            }
            return View();
        }

        public ActionResult MaterialsSetupDel(int repository_id, int matmodel_id, int count_delta)
        {
            Material model = new Material();

            List<Material> models = new List<Material>();
            string s = "REPOSITORY_ID = " + repository_id.ToString() +
                        " AND mat_model_id = " + matmodel_id.ToString() +
                        " AND status_id = 22 " +
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

                Store theStore = new Store();
                theStore = theStore.GetById(theMD.Store.ID);

                int nCount = theStore.StoreMatDetails.Count(x => x.Matmodel.ID == theMD.Matmodel.ID);
                if (nCount == 1) // Удаляется последняя позиция модели (S0029)
                {                                                            // => удаляем все устройства по данной позиции (S0029)
                    foreach (var item in (new Material()).GetAll("REPOSITORY_ID=" + theMD.Store.ID + " AND MAT_MODEL_ID=" + theMD.Matmodel.ID))
                    {
                        item.Delete(item);
                    }
                }

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

                Store theStore = new Store();
                theStore = theStore.GetById(theDD.Store.ID); 
                int nCount = theStore.StoreDevDetails.Count(x => x.Devmodel.ID == theDD.Devmodel.ID);
                if (nCount == 1) // Удаляется последняя позиция модели (S0029)
                {                                                            // => удаляем все устройства по данной позиции (S0029)
                    foreach (var item in (new Device()).GetAll("REPOSITORY_ID=" + theDD.Store.ID + " AND DEV_MODEL_ID=" + theDD.Devmodel.ID))
                    {
                        item.Delete(item);
                    }
                }

                theDD.Delete(theDD); // удаляем саму позиция (S0029)

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
            ViewBag.StoreID = id;
            ViewBag.MatmodelID = MatmodelID;
            ViewBag.Stores = (new Store()).GetAll();
            ViewBag.Devices = (new Device()).GetAll();
            ViewBag.Materials = (new Material()).GetAll("MAT_MODEL_ID="+ViewBag.MatmodelID) ;
            ViewBag.Materials1 = ((List<Material>)ViewBag.Materials).Where(x => x.StoreID == ViewBag.StoreID).Where(x => x.StatusID == 1);
            ViewBag.Materials22 = ((List<Material>)ViewBag.Materials).Where(x => x.StatusID == 22).Where(x => x.Store.ID == ViewBag.StoreID);
            ViewBag.Materials3 = ((List<Material>)ViewBag.Materials).Where(x => x.StatusID == 3).Where(x => x.Store.ID == ViewBag.StoreID);            
            ViewBag.Mathistory = (new Mathistory()).GetAll("STORE_ID=" + ViewBag.StoreID + " AND STATUS_ID=2");           
            return View();
        }

        public ActionResult ShowDevices(int id, int DevmodelID)
        {
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
            model.StatusID = status_id;
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
            model.DeviceID = device_id;
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

            // Проверяем есть ли дня нового склада - позиция добавляемых моделей материалов (S0026)
            if ( model.Store.StoreMatDetails.Count(x => x.Matmodel.ID == model.Matmodel.ID) == 0 )
            {
                StoreMatDetail detail = new StoreMatDetail();
                detail.Matmodel = (new Matmodel()).GetById(model.Matmodel.ID);
                detail.Store = (new Store()).GetById(store_id);
                detail.Save(detail);
            }
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
            model.RoomID = room_id;
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
            model.StatusID = 2;
            model.Update(model);

            model.StatusID = 1;
            model.Store = (new Store()).GetById(store_id);            
            
            model.Update(model);

            // Проверяем есть ли дня нового склада - позиция добавляемых моделей оборудования (S0026)
            if (model.Store.StoreDevDetails.Count(x => x.Devmodel.ID == model.Devmodel.ID) == 0)
            {
                StoreDevDetail detail = new StoreDevDetail();
                detail.Devmodel = (new Devmodel()).GetById(model.Devmodel.ID);
                detail.Store = (new Store()).GetById(store_id);
                detail.Save(detail);
            }

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


    }
}

