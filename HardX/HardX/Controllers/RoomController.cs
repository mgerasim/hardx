using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;

namespace HardX.Controllers
{
    public class RoomController : Controller
    {
        //
        // GET: /Room/

        public ActionResult Index()
        {
            Room model = new Room();
            List<Room> theListModel = new List<Room>();
            theListModel = (List<Room>)model.GetAll();

            return View(theListModel);
        }

        //
        // GET: /Room/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Room/Create

        public ActionResult Create()
        {
            RoomNew model = new RoomNew();
            return View(model);
        } 

        //
        // POST: /Room/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Room model = new Room();
                model.Name = collection["Name"];
                model.House = (new House()).GetById(Convert.ToInt32(collection["House"]));
                model.Save(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Room/Edit/5
 
        public ActionResult Edit(int id)
        {
            Room model = new Room();
            model = model.GetById(id);
            return View(model);
        }

        //
        // POST: /Room/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Room model = new Room();
                model = model.GetById(id);
                model.Name = collection["Name"];
                model.House = (new House()).GetById(Convert.ToInt32(collection["House.Id"]));

                int AreaID = 0;
                try
                {
                    AreaID = Convert.ToInt32(collection["Area.ID"]);
                    model.Area = (new Area()).GetById(AreaID);
                }
                catch
                {
                }

                model.Update(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Room/Delete/5
 
        public ActionResult Delete(int id)
        {
            Room model = new Room();
            model = model.GetById(id);

            model.Delete(model);

            return RedirectToAction("Index");
        }

        //
        // POST: /Room/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
