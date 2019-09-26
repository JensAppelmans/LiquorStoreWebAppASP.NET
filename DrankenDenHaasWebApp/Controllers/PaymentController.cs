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
    public class PaymentController : SessionController
    {
        private DrankencentraleDBJensAppelmansEntities db = new DrankencentraleDBJensAppelmansEntities();

        // GET: /Payment/
        public ActionResult Index()
        {
            List<PaymentViewModel> payments = new List<PaymentViewModel>();
            foreach (Payment p in db.Payments.Include(p => p.Debitcard).Include(p => p.Order).OrderBy(p => p.DatumVanBetaling))
                if (p.BetalingsId > 0)
                    payments.Add(new PaymentViewModel(p));
            return View(payments); 

            //var payments = db.Payments.Include(p => p.Debitcard).Include(p => p.Order);
            //return View(payments.ToList());
        }

        // GET: /Payment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentViewModel payVM = null;
            try
            {
                payVM = new PaymentViewModel(db.Payments.Find(id));
            }
            catch
            {
                return Index();
            }
            return View(payVM);
            //Payment payment = db.Payments.Find(id);
            //if (payment == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(payment);
        }

        // GET: /Payment/Create
        public ActionResult Create()
        {
            ViewBag.BetaalKaartId = new SelectList(db.Debitcards, "BetaalkaartId", "Id");
            ViewBag.BestelId = new SelectList(db.Orders, "BestelId", "BestelId");
            return View();
        }

        // POST: /Payment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BetalingsId,DatumVanBetaling,BedragBetaald,BetaalKaartId,BestelId")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Add(payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BetaalKaartId = new SelectList(db.Debitcards, "BetaalkaartId", "Id", payment.BetaalKaartId);
            ViewBag.BestelId = new SelectList(db.Orders, "BestelId", "BestelId", payment.BestelId);
            return View(payment);
        }

        // GET: /Payment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PaymentViewModel payVM = null;
            try
            {
                payVM = new PaymentViewModel(db.Payments.Find(id));
            }
            catch
            {
                return HttpNotFound();
            }
            ViewBag.BetaalKaartId = new SelectList(db.Debitcards, "BetaalkaartId", "Id", payVM.BetaalKaartId);
            ViewBag.BestelId = new SelectList(db.Orders, "BestelId", "BestelId", payVM.BestelId);
            return View(payVM);

            //Payment payment = db.Payments.Find(id);
            //if (payment == null)
            //{
            //    return HttpNotFound();
            //}
            
            //return View(payment);
        }

        // POST: /Payment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BetalingsId,DatumVanBetaling,BedragBetaald,BetaalKaartId,BestelId")] PaymentViewModel payment)
        {
            if (ModelState.IsValid)
            {
                Payment pay = new Payment(payment); 
                db.Entry(pay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BetaalKaartId = new SelectList(db.Debitcards, "BetaalkaartId", "Id", payment.BetaalKaartId);
            ViewBag.BestelId = new SelectList(db.Orders, "BestelId", "BestelId", payment.BestelId);
            return View(payment);
        }

        // GET: /Payment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PaymentViewModel payVM = null;
            try
            {
                payVM = new PaymentViewModel(db.Payments.Find(id));
            }
            catch
            {
                return HttpNotFound();
            }
            return View(payVM); 
            //Payment payment = db.Payments.Find(id);
            //if (payment == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(payment);
        }

        // POST: /Payment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = db.Payments.Find(id);
            db.Payments.Remove(payment);
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
