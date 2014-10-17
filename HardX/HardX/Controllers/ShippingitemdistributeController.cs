using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;

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
            theModel.Count = count;
            theModel.Save(theModel);
            return View(theModel);
        }

    }
}
