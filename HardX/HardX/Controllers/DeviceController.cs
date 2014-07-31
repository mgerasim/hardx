using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;
using HardX.Utils;

namespace HardX.Controllers
{
    public class DeviceController : Controller
    {
        //
        // GET: /Device/

        public ActionResult Index()
        {
            if (!Access.HasAccess(46))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            return View();
        }
        
        //
        // GET: /Device/Delete/5

        public ActionResult Delete(int id)
        {
            if (!Access.HasAccess(50))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Device item = new Device();
            item = item.GetById(id);
            item.Delete(item);
            return View();
        }

        public ActionResult Refund(int id)
        {
            if (!Access.HasAccess(50))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Device item = new Device();
            item = item.GetById(id);
            item.StatusID = 1;
            item.IPAddr = "";
            item.Host = "";
            item.Update(item);
            return View();
        }


    }
}
