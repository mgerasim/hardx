using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;

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

    }
}
