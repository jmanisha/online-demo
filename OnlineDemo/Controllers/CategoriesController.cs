using OnlineDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineDemo.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _context;
        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var category = _context.Categories.Where(x=>x.IsDeleted==false).ToList();
            return View(category);
        }

        public ActionResult Details(int id)
        {
            var category = _context.Categories.SingleOrDefault(x => x.CategoryId == id);
            if (category == null)
                return HttpNotFound();
            return View(category);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Categories category)
        {
            if(!ModelState.IsValid)
            {
                return View("New");
            }
            else
            {
                if (category.CategoryId == 0 || category.CategoryId == null)
                    _context.Categories.Add(category);
                else
                {
                    var categorymodel = _context.Categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);
                    categorymodel.CategoryName = category.CategoryName;
                }
                _context.SaveChanges();
                return RedirectToAction("Index", "Categories");
            }
            

        }
        // GET: Categories
        public ActionResult Random()
        {
            var category = new Categories() { CategoryName = "Beauty" };

            return View(category);
        }

        public ActionResult Edit(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryId == id);
            if (category == null)
                return HttpNotFound();
            return View("New", category);
        }

        [HttpPost]

        public ActionResult DeleteCat(int CatId)
        {
            var category = _context.Categories.SingleOrDefault(p => p.CategoryId == CatId);
            if (category == null)
            {
                return HttpNotFound();
            }

            category.IsDeleted = true;
            //_context.Categories.Remove(category);
            _context.SaveChanges();
            return new EmptyResult();
        }
    }
}