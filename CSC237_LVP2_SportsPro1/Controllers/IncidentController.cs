using CSC237_LVP2_SportsPro1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_LVP2_SportsPro1.Controllers
{
    public class IncidentController : Controller
    {
        private SportsProContext context;

        public IncidentController(SportsProContext ctx)
        {
            context = ctx;
        }

        [Route("[controller]s")]
        public IActionResult List()
        {
            List<Incident> incidents = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .OrderBy(i => i.DateOpened)
                .ToList();
            return View(incidents);
        }

        public void StoreListsInViewBag()
        {
            ViewBag.Customers = context.Customers
                .OrderBy(c => c.FirstName)
                .ToList();

            ViewBag.Products = context.Products
                .OrderBy(p => p.Name)
                .ToList();

            ViewBag.Technicians = context.Technicians
                .OrderBy(t => t.Name)
                .ToList();
        }
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            StoreListsInViewBag();
            return View("AddEdit", new Incident());
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            StoreListsInViewBag();
            var incident = context.Incidents.Find(id);
            return View("AddEdit", incident);
        }

        [HttpPost]
        public IActionResult Save(Incident incident)
        {
            if (ModelState.IsValid)
            {
                if (incident.IncidentID == 0)
                {
                    context.Incidents.Add(incident);
                }
                else
                {
                    context.Incidents.Update(incident);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                StoreListsInViewBag();
                if (incident.IncidentID == 0)
                {
                    ViewBag.Action = "Add";
                }
                else
                {
                    ViewBag.Action = "Edit";
                }
                return View("AddEdit", incident);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = context.Incidents.Find(id);
            return View(incident);
        }
        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            context.Incidents.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
