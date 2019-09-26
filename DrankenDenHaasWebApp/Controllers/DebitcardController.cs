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
    public class DebitcardController : SessionController
    {
        private DrankencentraleDBJensAppelmansEntities db = new DrankencentraleDBJensAppelmansEntities();

        // GET: /Debitcard/
        public ActionResult Index()
        {
            List<DebitcardViewModel> cards = new List<DebitcardViewModel>();
            foreach (Debitcard p in db.Debitcards.OrderBy(deb => deb.KaartNaam))
                if (p.BetaalkaartId > 0)
                    cards.Add(new DebitcardViewModel(p));
            return View(cards);
            
            
            //return View(db.Debitcards.ToList());
        }

        // GET: /Debitcard/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebitcardViewModel cardVM = null;
            try
            {
                cardVM = new DebitcardViewModel(db.Debitcards.Find(id));
            }
            catch
            {
                return Index();
            }
            return View(cardVM);
            //Debitcard debitcard = db.Debitcards.Find(id);
            //if (debitcard == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(debitcard);
        }

        // GET: /Debitcard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Debitcard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BetaalkaartId,Id,KaartNaam,Kaartnummer,DatumGeldigTot,Primairekaart")] Debitcard debitcard)
        {
            if (ModelState.IsValid)
            {
                db.Debitcards.Add(debitcard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(debitcard);
        }

        // GET: /Debitcard/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebitcardViewModel cardVM = null;
            try
            {
                cardVM = new DebitcardViewModel(db.Debitcards.Find(id));
            }
            catch
            {
                return HttpNotFound();
            }
            return View(cardVM);
            //Debitcard debitcard = db.Debitcards.Find(id);
            //if (debitcard == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(debitcard);
        }

        // POST: /Debitcard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BetaalkaartId,Id,KaartNaam,Kaartnummer,DatumGeldigTot,Primairekaart")] DebitcardViewModel debitcard)
        {
            if (ModelState.IsValid)
            {
                Debitcard card = new Debitcard(debitcard); 
                db.Entry(card).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(debitcard);
        }

        // GET: /Debitcard/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebitcardViewModel cardVM = null;
            try
            {
                cardVM = new DebitcardViewModel(db.Debitcards.Find(id));
            }
            catch
            {
                return HttpNotFound();
            }
            return View(cardVM);
            //Debitcard debitcard = db.Debitcards.Find(id);
            //if (debitcard == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(debitcard);
        }

        // POST: /Debitcard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Debitcard debitcard = db.Debitcards.Find(id);
            db.Debitcards.Remove(debitcard);
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
