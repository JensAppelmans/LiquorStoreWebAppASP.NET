using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Web.Mvc;
using DrankenDenHaasWebApp.Models;

namespace DrankenDenHaasWebApp.Controllers
{
    public class OrderController : SessionController
    {
        private DrankencentraleDBJensAppelmansEntities db = new DrankencentraleDBJensAppelmansEntities();

        // GET: /Order/
        public ActionResult Index()
        {
           
                List<OrderViewModel> orders = new List<OrderViewModel>();
                foreach (Order p in db.Orders.OrderBy(ord => ord.DatumVanBestelling).Include(o => o.Customer))
                    if (p.BestelId > 0)
                        orders.Add(new OrderViewModel(p));
                return View(orders);
        
        }
        public ActionResult PersonOrder(string id)
        {
            List<OrderViewModel> orders = new List<OrderViewModel>();
            foreach (Order p in db.Orders.Where(c => c.Customer.UserId == id).OrderBy(ord => ord.DatumVanBestelling).Include(o => o.Customer))
                if (p.BestelId > 0)
                    orders.Add(new OrderViewModel(p));
            return View(orders);
        }
        // GET: /Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderViewModel orderVM = null;
            try
            {
                orderVM = new OrderViewModel(db.Orders.Find(id));
            }
            catch
            {
                return Index();
            }
            return View(orderVM);


            //Order order = db.Orders.Find(id);
            //if (order == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(order);
        }

        // GET: /Order/Create
        
        public ActionResult Create(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string userId = User.Identity.GetUserId();
            int customerId = 0; 
            Customer co = db.Customers.FirstOrDefault(c => c.UserId == userId);
            if (co == null)
            {
                Customer cust = new Customer();
                cust.UserId = userId;

                db.Customers.Add(cust);
                db.SaveChanges();
                customerId = cust.KlantId;

            }
            else
            {
                customerId = co.KlantId; 
            }
            
            Order order = new Order() { DatumVanBestelling = DateTime.Now, Id = customerId, IsBetaald = true, Totaalprijs = decimal.Parse(id) };  
            db.Orders.Add(order);
            db.SaveChanges();
            int orderId = order.BestelId;

            foreach (Shopbasket shop in Shopbasket.winkelmandje)
            {
                Orders_Products ordProd = new Orders_Products() { Aantal = shop.Aantal, Prijs_Item = shop.Prijs, Subtotaal = shop.Prijs * shop.Aantal, ProductId = shop.Id, BestelId = orderId };
                db.Orders_Products.Add(ordProd);
                db.SaveChanges();
            }
            TempData["Message"] = "OK"; 
            Shopbasket.winkelmandje.Clear();

            //return new EmptyResult(); 

            return RedirectToAction("Index", "Home", null);
        }

        // POST: /Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BestelId,Id,DatumVanBestelling,Totaalprijs,IsBetaald")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Customers, "KlantId", "UserId", order.Id);
            return View(order);
        }

        // GET: /Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            OrderViewModel orderVM = null;
            try
            {
                orderVM = new OrderViewModel(db.Orders.Find(id));
            }
            catch
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Customers, "KlantId", "UserId", orderVM.Id);
            return View(orderVM);

            //Order order = db.Orders.Find(id);
            //if (order == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.Id = new SelectList(db.Customers, "KlantId", "UserId", order.Id);
            //return View(order);
        }

        // POST: /Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BestelId,Id,DatumVanBestelling,Totaalprijs,IsBetaald")] OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                Order ord = new Order(order);
                db.Entry(ord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Customers, "KlantId", "UserId", order.Id);
            return View(order);
        }

        // GET: /Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            OrderViewModel orderVM = null;
            try
            {
                orderVM = new OrderViewModel(db.Orders.Find(id));
            }
            catch
            {
                return HttpNotFound();
            }

            return View(orderVM);
            //Order order = db.Orders.Find(id);
            //if (order == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(order);
        }

        // POST: /Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
