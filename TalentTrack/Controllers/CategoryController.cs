using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalentTrack.Models;

namespace TalentTrack.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();    
        }

        public ActionResult DisplayCategory()
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                return View(t.tblCategories.ToList());
            }
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                return View(t.tblCategories.Where(category=>category.categoryId==id).FirstOrDefault());
            }
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,tblCategory x)
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                t.Entry(x).State = System.Data.Entity.EntityState.Modified;
                t.SaveChanges();
                return RedirectToAction("DisplayCategory");
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                tblCategory x = t.tblCategories.Where(category => category.categoryId == id).FirstOrDefault();
                t.tblCategories.Remove(x);
                t.SaveChanges();
                return RedirectToAction("DisplayCategory");
            }
        }

        // POST: Category/Delete/5
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
