using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DrankenDenHaasWebApp;

namespace DrankenDenHaasWebApp.Controllers
{
    public class Order_ProductController : SessionController
    {
        private DrankencentraleDBJensAppelmansEntities db = new DrankencentraleDBJensAppelmansEntities();

        // GET: /Order_Product/
        //Deze index werkt iets anders als de vorige, hier gaan we filteren op het id van het bestelnummer dat we meegeven.
        //We willen dus enkel een lijst zien van een bepaald bestelId
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<Order_ProductsViewModel> orderProd = new List<Order_ProductsViewModel>();
            foreach (Orders_Products p in db.Orders_Products.Where(p => p.BestelId == id).Include(p => p.Order).Include(p => p.Product).OrderBy(p => p.BestelId))
                if (p.ProductId > 0 && p.BestelId > 0)
                    orderProd.Add(new Order_ProductsViewModel(p));
            return View(orderProd); 
            
        }

        //// GET: /Order_Product/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order_ProductsViewModel ord_prodVM = null;
        //    try
        //    {
        //        ord_prodVM = new Order_ProductsViewModel(db.Orders_Products.Find(id));
        //    }
        //    catch
        //    {
        //        //return Index();
        //    }
        //    return View(ord_prodVM);

        //    //Orders_Products orders_products = db.Orders_Products.Find(id);
        //    //if (orders_products == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    //return View(orders_products);
        //}

        // GET: /Order_Product/Create
        public ActionResult Create()
        {
            ViewBag.BestelId = new SelectList(db.Orders, "BestelId", "BestelId");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Productnaam");
            return View();
        }

        // POST: /Order_Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BestelId,ProductId,Aantal,Prijs_Item,Subtotaal")] Orders_Products orders_products)
        {
            if (ModelState.IsValid)
            {
                db.Orders_Products.Add(orders_products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BestelId = new SelectList(db.Orders, "BestelId", "BestelId", orders_products.BestelId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Productnaam", orders_products.ProductId);
            return View(orders_products);
        }

        // GET: /Order_Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order_ProductsViewModel ord_prodVM = null;
            try
            {
                ord_prodVM = new Order_ProductsViewModel(db.Orders_Products.Find(id));
            }
            catch
            {
                return HttpNotFound();
            }
            ViewBag.BestelId = new SelectList(db.Orders, "BestelId", "BestelId", ord_prodVM.BestelId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Productnaam", ord_prodVM.ProductId);
            return View(ord_prodVM);
            
            //Orders_Products orders_products = db.Orders_Products.Find(id);
            //if (orders_products == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.BestelId = new SelectList(db.Orders, "BestelId", "BestelId", orders_products.BestelId);
            //ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Productnaam", orders_products.ProductId);
            //return View(orders_products);
        }

        // POST: /Order_Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BestelId,ProductId,Aantal,Prijs_Item,Subtotaal")] Order_ProductsViewModel orders_products)
        {
            if (ModelState.IsValid)
            {
                Orders_Products ord = new Orders_Products(orders_products); 
                db.Entry(ord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BestelId = new SelectList(db.Orders, "BestelId", "BestelId", orders_products.BestelId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Productnaam", orders_products.ProductId);
            return View(orders_products);
        }

        // GET: /Order_Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order_ProductsViewModel ord_prodVM = null;
            try
            {
                ord_prodVM = new Order_ProductsViewModel(db.Orders_Products.Find(id));
            }
            catch
            {
                return HttpNotFound();
            }
            return View(ord_prodVM);
            //Orders_Products orders_products = db.Orders_Products.Find(id);
            //if (orders_products == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(orders_products);
        }

        // POST: /Order_Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders_Products orders_products = db.Orders_Products.Find(id);
            db.Orders_Products.Remove(orders_products);
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
