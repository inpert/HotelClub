using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelClub.Core;
using HotelClub.Data;
using HotelClub.Interface;

namespace HotelClub.Web.Controllers
{
    public class HotelController : Controller
    {
        private IApplicationUnit db;// = new MainContext();

        public HotelController(IApplicationUnit _db)
        {
            db = _db;
        }

        //
        // GET: /Hotel/

        public ActionResult Index()
        {
            return View(db.Hotels.GetAll());
        }

        //
        // GET: /Hotel/Details/5

        public ActionResult Details(int id = 0)
        {
            Hotel hotel = db.Hotels.GetById(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        //
        // GET: /Hotel/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Hotel/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hotel hotel)
        {
            if (db.Hotels.GetAll().Count() >= 7)
            {
                ViewBag.ErrorMessage = "You already have too many Hotels, please delete at leaset one to add another.";
                return View(hotel);
            }
                

            if (ModelState.IsValid)
            {
                db.Hotels.Add(hotel);
                db.Hotels.Save();
                return RedirectToAction("Index");
            }

            return View(hotel);
        }

        //
        // GET: /Hotel/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Hotel hotel = db.Hotels.GetById(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        //
        // POST: /Hotel/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Hotel hotel)
        {
            if (hotel.Id < 4)
            {
                ViewBag.ErrorMessage = "It's a protected Hotel, you can't any information";
                return View(hotel);
            }
                

            if (ModelState.IsValid)
            {
                var modelHotel = db.Hotels.GetById(hotel.Id);
                db.Hotels.Update(modelHotel);
                modelHotel.Name = hotel.Name;                
                db.Hotels.Save();
                return RedirectToAction("Index");
            }
            return View(hotel);
        }

        //
        // GET: /Hotel/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Hotel hotel = db.Hotels.GetById(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        //
        // POST: /Hotel/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotel hotel = db.Hotels.GetById(id);
            db.Hotels.Remove(hotel);
            db.Hotels.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Hotels.Dispose();
            base.Dispose(disposing);
        }
    }
}