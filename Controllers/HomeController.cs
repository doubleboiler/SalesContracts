using SellContracts.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace SellContracts.Controllers
{
    public class HomeController : Controller
    {
        SaleContext db = new SaleContext();
        public IEnumerable<Agent> GetAllAg()
        {
            return db.Agents;
        }
        public IEnumerable<Client> GetAllCli()
        {
            return db.Clients;
        }
        public ActionResult Index()
        {
            var sale = db.Sales.Include(s => s.Agent)
                               .Include(s => s.Client);
            return View(sale.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.AgentId = new SelectList(GetAllAg(), "Id", "Name");
            ViewBag.ClientId = new SelectList(GetAllCli(), "Id", "Name");
            ViewBag.Company = new SelectList(GetAllCli(), "Id", "Company");

            return PartialView("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sale sale)
        {
            ViewBag.AgentId = new SelectList(GetAllAg(), "Id", "Name", sale.AgentId);
            ViewBag.ClientId = new SelectList(GetAllCli(), "Id", "Name", sale.ClientId);
            ViewBag.Company = new SelectList(GetAllCli(), "Id", "Company", sale.ClientId);
            db.Sales.Add(sale);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {

            Sale sale = db.Sales.Find(id);
            ViewBag.AgentId = new SelectList(GetAllAg(), "Id", "Name", sale.AgentId);
            ViewBag.ClientId = new SelectList(GetAllCli(), "Id", "Name", sale.ClientId);
            ViewBag.Company = new SelectList(GetAllCli(), "Id", "Company", sale.ClientId);
            
            if (sale != null)
            {
                return PartialView("Edit", sale);
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sale sale)
        {
            db.Entry(sale).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Sale sale = db.Sales.Find(id);
            if (sale != null)
            {
                return PartialView("Delete", sale);
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteRecord(int id)
        {
            Sale sale = db.Sales.Find(id);

            if (sale != null)
            {
                db.Sales.Remove(sale);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}