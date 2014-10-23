using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;
using System.Net.Mail;

namespace HardX.Controllers
{
    public class ShippingitemdistributeController : Controller
    {
        //
        // GET: /Shippingitendistribute/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int shippingitem_id, int store_id, int count)
        {
            Shippingitemdistribute theModel = new Shippingitemdistribute();
            theModel.ShippingitemID = shippingitem_id;
            theModel.StoreID = store_id;
            theModel.Status = 1;
            theModel.Count = count;
            if ((new Shippingitemdistribute()).GetAll("SHIPPINGITEM_ID=" + shippingitem_id.ToString() + " AND STORE_ID=" + store_id.ToString()).Count > 0)
            {
                Shippingitemdistribute theUpdate = (new Shippingitemdistribute()).GetAll("SHIPPINGITEM_ID=" + shippingitem_id.ToString() + " AND STORE_ID=" + store_id.ToString())[0];
                theUpdate.ShippingitemID = shippingitem_id;
                theUpdate.StoreID = store_id;
                theUpdate.Count = count;
                theUpdate.Status = 1;
                theUpdate.Update(theUpdate);
                return View(theUpdate);
            }
            else
            {
                theModel.ShippingitemID = shippingitem_id;
                theModel.StoreID = store_id;
                theModel.Count = count;
                theModel.Save(theModel);
                return View(theModel);
            }            
        }

        public ActionResult Details()
        {
            int i = Models.User.CurrentUserId;
            IEnumerable<string> store_numbers = (new Store()).GetAll("USER_ID=" + Models.User.CurrentUserId + " OR USER2_ID=" + Models.User.CurrentUserId).Select(a => a.ID.ToString());
            string str_store_numbers = string.Join(", ", store_numbers);

            List<Shippingitem> theShippingitem =(List<Shippingitem>) (new Shippingitem()).GetAll();
            IEnumerable<string> shippingitem_numbers = theShippingitem.Select(a => a.ID.ToString());
            string str_shippingitem_numbers = string.Join(", ", shippingitem_numbers);

            IEnumerable<string> storeid_numbers = (new Shippingitemdistribute()).GetAll("STORE_ID in ("+str_store_numbers+") AND SHIPPINGITEM_ID in (" + str_shippingitem_numbers + ")").Select(a => a.StoreID.ToString()).Distinct();
            string str_storeid_numbers = string.Join(", ", storeid_numbers);

            ViewBag.theDistribute = (new Shippingitemdistribute()).GetAll("STATUS=2 AND STORE_ID in(" + str_storeid_numbers + ")");
            ViewBag.theShippingitem = theShippingitem;

            return View();
        }

        public ActionResult Commit(int distr_id, int store_id, int matmodel_id, int devmodel_id)
        {
            Shippingitemdistribute theDistr = new Shippingitemdistribute();
            theDistr = theDistr.GetById(distr_id);
            if (matmodel_id > 0)
            {
                for (int i = 0; i < theDistr.Count; i++)
                {
                    Material model = new Material();
                    model.Matmodel = (new Matmodel()).GetById(matmodel_id);
                    model.Store = (new Store()).GetById(store_id);
                    model.StatusID = 1;
                    model.Save(model);
                }
                theDistr.Status = 3;
                theDistr.Update(theDistr);
            }

            if (devmodel_id > 0)
            {
                for (int i = 0; i < theDistr.Count; i++)
                {
                    Device model = new Device();
                    model.Devmodel = (new Devmodel()).GetById(devmodel_id);
                    model.Store = (new Store()).GetById(store_id);
                    model.StatusID = 1;
                    model.Save(model);
                }
                theDistr.Status = 3;
                theDistr.Update(theDistr);
            }

            return View();
        }
        

    }
}
