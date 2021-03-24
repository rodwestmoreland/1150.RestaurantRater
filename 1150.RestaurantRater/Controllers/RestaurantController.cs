using _1150.RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1150.RestaurantRater.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantDBContext _context = new RestaurantDBContext();
        
        public ActionResult Index() =>          View(_context.Restaurants.ToList());
        public ActionResult Create() =>         View();
        public ActionResult Delete(int? id) =>  ValidateIdInput(id);
        public ActionResult Edit(int? id) =>    ValidateIdInput(id);
        public ActionResult Details(int? id) => ValidateIdInput(id);

        private ActionResult ValidateIdInput(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            Restaurant restaurant = _context.Restaurants.Find(id);

            if (restaurant == null) return HttpNotFound();

            return View(restaurant);
        }

        private ActionResult SaveAndRedirect()
        {
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _context.Restaurants.Add(restaurant);
                return SaveAndRedirect();
            }
            return View(restaurant);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Restaurant restaurant = _context.Restaurants.Find(id);
            _context.Restaurants.Remove(restaurant);
            return SaveAndRedirect();
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(restaurant).State = System.Data.Entity.EntityState.Modified;
                return SaveAndRedirect();
            }
            return View(restaurant);
        }
    }
}