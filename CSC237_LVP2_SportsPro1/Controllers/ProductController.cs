using CSC237_LVP2_SportsPro1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_LVP2_SportsPro1.Controllers
{
    public class ProductController : Controller
    {
        private SportsProContext context { get; set; }

        public ProductController(SportsProContext ctx)
        {
            context = ctx;
        }

        [Route("[controller]s")]
        public ViewResult List()
        {
            List<Product> products = context.Products.OrderBy(p => p.ReleaseDate).ToList();
            return View(products);
        }
        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Action = "Add";
            return View("AddEdit", new Product());
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var product = context.Products.Find(id);
            return View("AddEdit", product);
        }

        [HttpPost]
        public IActionResult Save(Product product)
        {
            string message;
            if (product.ProductID == 0)
            {
                ViewBag.Action = "Add";
            }
            else
            {
                ViewBag.Action = "Edit";
            }
            if (ModelState.IsValid)
            {
                if (ViewBag.Action == "Add")
                {
                    context.Products.Add(product);
                    message = product.Name + " was added.";
                }
                else
                {
                    context.Products.Update(product);
                    message = product.Name + " was updated.";
                }
                context.SaveChanges();
                TempData["message"] = message;
                return RedirectToAction("List");
            }
            else
            {

                return View("AddEdit", product);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var product = context.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public RedirectToActionResult Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
