using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DrankenDenHaasWebApp;
using DrankenDenHaasWebApp.Models;

namespace DrankenDenHaasWebApp.Controllers
{
    public class ShopbasketController : SessionController
    {
        private DrankencentraleDBJensAppelmansEntities db = new DrankencentraleDBJensAppelmansEntities();



        // GET: Shopbasket
        public ActionResult Index()
        {
            //foreach (Shopbasket shop in Shopbasket.winkelmandje)
            //    if (shop.Id > 0)
            //    {
            //        return View(shop);
            //    }

            //if ((List<Shopbasket>)Session["Winkelmandje"] != null)
            //{

            //    return View((List<Shopbasket>)Session["Winkelmandje"]);
            //}
            if (TempData["Message"] != null)
            {
                ViewBag.Message = "OK"; 
            }
            return View(Shopbasket.winkelmandje); 
        }

        
        // GET: Shopbasket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopbasket shopbasket = Shopbasket.Find(id);
            if (shopbasket == null)
            {
                return HttpNotFound();
            }
            return View(shopbasket);
        }

        // POST: Shopbasket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Prijs,Aantal,ProductNaam,ImagePath")] Shopbasket shopbasket)
        {
            if (ModelState.IsValid)
            {
                Shopbasket.VoegToe(shopbasket);

                //Session["Winkelmandje"] = Shopbasket.winkelmandje;
            }

            return new EmptyResult();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Shopbasket shopbasket = Shopbasket.Find(id);
            if (shopbasket == null)
            {
                return HttpNotFound();
            }
            return View(shopbasket);
        }

        // POST: Shopbasket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Prijs,Aantal,ProductNaam,ImagePath")] Shopbasket shopbasket)
        {
            if (ModelState.IsValid)
            {
                var oldValue = Shopbasket.winkelmandje.First(p => p.Id == shopbasket.Id);
                var newValue = shopbasket;
                newValue.ImagePath = oldValue.ImagePath; 
                int index = Shopbasket.winkelmandje.IndexOf(oldValue);
                if (index != -1)
                    Shopbasket.winkelmandje[index] = newValue;
                return RedirectToAction("Index");
            }
            return View(shopbasket);
        }

        // GET: Shopbasket/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopbasket shopbasket = Shopbasket.Find(id);
            if (shopbasket == null)
            {
                return HttpNotFound();
            }
            return View(shopbasket);
        }

        // POST: Shopbasket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shopbasket shopbasket = Shopbasket.Find(id);
            Shopbasket.winkelmandje.Remove(shopbasket);

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
