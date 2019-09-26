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
    //public class Multimedia_ProductController : SessionController
    //{
    //    private DrankencentraleDBJensAppelmansEntities db = new DrankencentraleDBJensAppelmansEntities();

    //    // GET: /Multimedia_Product/
    //    public ActionResult Index()
    //    {
    //        List<Multimedia_ProductsViewModel> mediaProducten = new List<Multimedia_ProductsViewModel>();
    //        foreach (Multimedia_Products p in db.Multimedia_Products.Include(m => m.Multimedia).Include(m => m.Product).OrderBy(m => m.ProductId))
    //            if (p.MultimediaId > 0 && p.ProductId > 0)
    //                mediaProducten.Add(new Multimedia_ProductsViewModel(p));
    //        return View(mediaProducten); 

    //        //var multimedia_products = db.Multimedia_Products.Include(m => m.Multimedia).Include(m => m.Product);
    //        //return View(multimedia_products.ToList());
    //    }

    //    // GET: /Multimedia_Product/Details/5
    //    public ActionResult Details(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Multimedia_ProductsViewModel mul_prodVM = null;
    //        try
    //        {
    //            mul_prodVM = new Multimedia_ProductsViewModel(db.Multimedia_Products.Find(id));
    //        }
    //        catch
    //        {
    //            return Index();
    //        }
    //        return View(mul_prodVM);


    //        //Multimedia_Products multimedia_products = db.Multimedia_Products.Find(id);
    //        //if (multimedia_products == null)
    //        //{
    //        //    return HttpNotFound();
    //        //}
    //        //return View(multimedia_products);
    //    }

    //    // GET: /Multimedia_Product/Create
    //    public ActionResult Create()
    //    {
    //        ViewBag.MultimediaId = new SelectList(db.Multimedias, "MultimediaId", "MultimediaId");
    //        ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Productnaam");
    //        return View();
    //    }

    //    // POST: /Multimedia_Product/Create
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create([Bind(Include="ProductId,MultimediaId,Foto")] Multimedia_Products multimedia_products)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Multimedia_Products.Add(multimedia_products);
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }

    //        ViewBag.MultimediaId = new SelectList(db.Multimedias, "MultimediaId", "MultimediaId", multimedia_products.MultimediaId);
    //        ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Productnaam", multimedia_products.ProductId);
    //        return View(multimedia_products);
    //    }

    //    // GET: /Multimedia_Product/Edit/5
    //    public ActionResult Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        //Multimedia_Products multimedia_products = db.Multimedia_Products.Find(id);
    //        //if (multimedia_products == null)
    //        //{
    //        //    return HttpNotFound();
    //        //}

    //        Multimedia_ProductsViewModel mul_prodVM = null;
    //        try
    //        {
    //            mul_prodVM = new Multimedia_ProductsViewModel(db.Multimedia_Products.Find(id));
    //        }
    //        catch
    //        {
    //            return HttpNotFound();
    //        }
            
    //        ViewBag.MultimediaId = new SelectList(db.Multimedias, "MultimediaId", "MultimediaId", mul_prodVM.MultimediaId);
    //        ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Productnaam", mul_prodVM.ProductId);
    //        return View(mul_prodVM);
    //        //return View(multimedia_products);
    //    }

    //    // POST: /Multimedia_Product/Edit/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit([Bind(Include="ProductId,MultimediaId,Foto")] Multimedia_ProductsViewModel multimedia_products)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            Multimedia_Products mul_prod = new Multimedia_Products(multimedia_products); 
    //            db.Entry(mul_prod).State = EntityState.Modified;
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }
    //        ViewBag.MultimediaId = new SelectList(db.Multimedias, "MultimediaId", "MultimediaId", multimedia_products.MultimediaId);
    //        ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Productnaam", multimedia_products.ProductId);
    //        return View(multimedia_products);
    //    }

    //    // GET: /Multimedia_Product/Delete/5
    //    public ActionResult Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Multimedia_ProductsViewModel mul_prodVM = null;
    //        try
    //        {
    //            mul_prodVM = new Multimedia_ProductsViewModel(db.Multimedia_Products.Find(id));
    //        }
    //        catch
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(mul_prodVM);
    //        //Multimedia_Products multimedia_products = db.Multimedia_Products.Find(id);
    //        //if (multimedia_products == null)
    //        //{
    //        //    return HttpNotFound();
    //        //}
    //        //return View(multimedia_products);
    //    }

    //    // POST: /Multimedia_Product/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult DeleteConfirmed(int id)
    //    {
    //        Multimedia_Products multimedia_products = db.Multimedia_Products.Find(id);
    //        db.Multimedia_Products.Remove(multimedia_products);
    //        db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            db.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }
    //}
}
