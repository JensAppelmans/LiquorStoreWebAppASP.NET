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
    public class ProducerController : SessionController
    {
        private DrankencentraleDBJensAppelmansEntities db = new DrankencentraleDBJensAppelmansEntities();

        // GET: /Producer/
        public ActionResult Index()
        {
            List<ProducerViewModel> producers = new List<ProducerViewModel>();
            foreach (Producer p in db.Producers.OrderBy(prod => prod.ProducentNaam))
                if (p.ProducentId > 0)
                    producers.Add(new ProducerViewModel(p));
            return View(producers);
            
           // return View(db.Producers.ToList());
        }

        // GET: /Producer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProducerViewModel prodVM = null;
            try
            {
                prodVM = new ProducerViewModel(db.Producers.Find(id));
            }
            catch
            {
                return Index();
            }
            return View(prodVM);
            //Producer producer = db.Producers.Find(id);
            //if (producer == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(producer);
        }

        // GET: /Producer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Producer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ProducentId,ProducentNaam,Land")] Producer producer)
        {
            if (ModelState.IsValid)
            {
                db.Producers.Add(producer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producer);
        }

        // GET: /Producer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducerViewModel prodVM = null;
            try
            {
                prodVM = new ProducerViewModel(db.Producers.Find(id));
            }
            catch
            {
                return HttpNotFound();
            }
            return View(prodVM);
            //Producer producer = db.Producers.Find(id);
            //if (producer == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(producer);
        }

        // POST: /Producer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ProducentId,ProducentNaam,Land")] ProducerViewModel producer)
        {
            if (ModelState.IsValid)
            {
                Producer prod = new Producer(producer); 
                db.Entry(prod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producer);
        }

        // GET: /Producer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducerViewModel prodVM = null;
            try
            {
                prodVM = new ProducerViewModel(db.Producers.Find(id));
            }
            catch
            {
                return HttpNotFound();
            }
            return View(prodVM);
            //Producer producer = db.Producers.Find(id);
            //if (producer == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(producer);
        }

        // POST: /Producer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producer producer = db.Producers.Find(id);
            db.Producers.Remove(producer);
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
