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
    public class ProductController : SessionController
    {
        private DrankencentraleDBJensAppelmansEntities db = new DrankencentraleDBJensAppelmansEntities();

        // GET: /Product/
        public ActionResult Index()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            foreach (Product p in db.Products.Include(p => p.Category).Include(p => p.Producer).OrderBy(p => p.Prijs))
                if (p.ProductId > 0)
                    products.Add(new ProductViewModel(p));
            return View(products.OrderBy(p => p.Prijs));
            
        }

        // GET: /Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductViewModel prodVM = null;
            try
            {
                
                prodVM = new ProductViewModel(db.Products.Find(id));
            }
            catch
            {
                return Index();
            }
            return View(prodVM);

        }

        // GET: /Product/Create
        public ActionResult Create()
        {
            ViewBag.CategorieId = new SelectList(db.Categories, "CategorieId", "Categorienaam");
            ViewBag.ProducentId = new SelectList(db.Producers, "ProducentId", "ProducentNaam");

            if (TempData["shortMessage"] != null && TempData["path"] != null /*&& TempData["id"] != null*/)
            {
                ViewBag.Message = TempData["shortMessage"].ToString();
                ViewBag.Path = TempData["path"].ToString();

                //int id = (int)TempData["id"];
            }



            return View();
        }


        // POST: /Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId, Productnaam,Prijs,Beschrijving,CategorieId,AlcoholPercentage___,Inhoud_cl_,ProducentId,VerkochtPer")] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                
                Product prod = new Product(product);

                Multimedia media = new Multimedia();
                if (TempData["image"] != null)
                {
                    media = (Multimedia)TempData["image"];
                }

                db.Products.Add(prod);
                db.SaveChanges();

                int productId = prod.ProductId; 
                media.ProductId = productId;

                db.Multimedias.Add(media);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CategorieId = new SelectList(db.Categories, "CategorieId", "Categorienaam", product.CategorieId);
            ViewBag.ProducentId = new SelectList(db.Producers, "ProducentId", "ProducentNaam", product.ProducentId);
            return View(product);
        }

        // GET: /Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductViewModel prodVM = null;
            try
            {
                prodVM = new ProductViewModel(db.Products.Find(id));
            }
            catch
            {
                return HttpNotFound();
            }
            ViewBag.CategorieId = new SelectList(db.Categories, "CategorieId", "Categorienaam", prodVM.CategorieId);
            ViewBag.ProducentId = new SelectList(db.Producers, "ProducentId", "ProducentNaam", prodVM.ProducentId);
            return View(prodVM);

        }

        // POST: /Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Productnaam,Prijs,Beschrijving,CategorieId,AlcoholPercentage___,Inhoud_cl_,ProducentId,VerkochtPer")] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                Product prod = new Product(product);
                db.Entry(prod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.CategorieId = new SelectList(db.Categories, "CategorieId", "Categorienaam", product.CategorieId);
            ViewBag.ProducentId = new SelectList(db.Producers, "ProducentId", "ProducentNaam", product.ProducentId);

            return View(product);
        }

        // GET: /Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductViewModel prodVM = null;
            try
            {
                prodVM = new ProductViewModel(db.Products.Find(id));
            }
            catch
            {
                return HttpNotFound();
            }
            return View(prodVM);

        }

        // POST: /Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Multimedia mul = db.Multimedias.FirstOrDefault(m => m.ProductId == id); 
            Product product = db.Products.Find(id);

            db.Multimedias.Remove(mul); 
            db.Products.Remove(product);
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
