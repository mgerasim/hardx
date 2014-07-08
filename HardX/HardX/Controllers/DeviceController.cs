using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;

namespace HardX.Controllers
{
    public class DeviceController : Controller
    {
        //
        // GET: /Device/

        public ActionResult Index()
        {
            return View();
        }
        
        //
        // GET: /Device/Delete/5

        public ActionResult Delete(int id)
        {
            Device item = new Device();
            item = item.GetById(id);
            item.Delete(item);
            return View();
        }
    }
}
