using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DrankenDenHaasWebApp;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace DrankenDenHaasWebApp.Controllers
{
    public class AdressController : SessionController
    {
        private DrankencentraleDBJensAppelmansEntities db = new DrankencentraleDBJensAppelmansEntities();

        // GET: /Adress/
        public ActionResult Index()
        {
            List<AdressViewModel> Adresses = new List<AdressViewModel>();
            foreach (Adress p in db.Adresses.OrderBy(adr => adr.Provincie))
                if (p.AdresId > 0)
                    Adresses.Add(new AdressViewModel(p));
            return View(Adresses);

            //return View(db.Adresses.ToList());
        }

        // GET: /Adress/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AdressViewModel adressVM = null;
            try
            {
                adressVM = new AdressViewModel(db.Adresses.Find(id));
            }
            catch
            {
                return Index();
            }
            return View(adressVM);



            //Adress adress = db.Adresses.Find(id);
            //if (adress == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(adress);
        }

        // GET: /Adress/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Adress/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AdresId,Land,Provincie,Stad,Postcode,Straatnaam,Nummer_Bus,UserId")] Adress adress)
        {
            if (ModelState.IsValid)
            {
                db.Adresses.Add(adress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adress);
        }

        // GET: /Adress/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdressViewModel adress = null; 
            try
            {
                adress = new AdressViewModel(db.Adresses.Find(id));
            }
            catch
            {
                return HttpNotFound();
            }
            // ViewBag.Language = new SelectList(Language.Languages.Where(l => l.Id != "? "), "Id", "Name", person.Language);
            return View(adress );
           
            //Adress adress = db.Adresses.Find(id);
            //if (adress == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(adress);
        }

        // POST: /Adress/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AdresId,Land,Provincie,Stad,Postcode,Straatnaam,Nummer_Bus,UserId")] AdressViewModel adress)
        {
            if (ModelState.IsValid)
            {
                Adress a = new Adress(adress);
                try
                {
                    db.Entry(a).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch(DbUpdateException e)
                {
                    Console.WriteLine(e); 
                }
                
                return RedirectToAction("Index");
            }
            return View(adress);
        }

        // GET: /Adress/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdressViewModel adress = null;
            try
            {
                adress = new AdressViewModel(db.Adresses.Find(id));
            }
            catch
            {
                return HttpNotFound();
            }
            return View(adress);
            //Adress adress = db.Adresses.Find(id);
            //if (adress == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(adress);
        }

        // POST: /Adress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adress adress = db.Adresses.Find(id);
            db.Adresses.Remove(adress);
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
