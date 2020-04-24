using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineDemo.Models;

namespace OnlineDemo.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _context;

        public ProductController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Product
        public ActionResult Index()
        {
            var products = _context.Product.ToList();

            return View(products);
        }

        public ActionResult New()
        {
            var categoryType = _context.Categories.ToList();
            var viewmodel = new ProductCategoryViewModel
            {
                Categories = categoryType
            };
            return View("ProductForm", viewmodel);
        }

        [HttpPost]
        public ActionResult Save(Product product)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new ProductCategoryViewModel
                {
                    Product = product,
                    Categories = _context.Categories.ToList()
                };
                return View("ProductForm", viewmodel);
            }
            else
            {
                if (product.ProductId == 0 || product.ProductId==null)
                    _context.Product.Add(product);
                else
                {
                    var productInDb = _context.Product.SingleOrDefault(p => p.ProductId == product.ProductId);
                    productInDb.ProductName = product.ProductName;
                    productInDb.CategoryId = product.CategoryId;
                }
                _context.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
        }

        public ActionResult Edit(int id)
        {
            var product = _context.Product.SingleOrDefault(p => p.ProductId == id);
            if (product == null)
                return HttpNotFound();
            var viewmodel = new ProductCategoryViewModel
            {
                Product = product,
                Categories = _context.Categories.ToList()
            };
            return View("ProductForm", viewmodel);
        }

        [HttpPost]

        public ActionResult DeleteProduct(int ProductId)
        {
            var product = _context.Product.SingleOrDefault(p => p.ProductId == ProductId);
            if(product==null)
            {
                return new EmptyResult();
            }

            _context.Product.Remove(product);
            _context.SaveChanges();
            
            return new EmptyResult();
        }
    }
}