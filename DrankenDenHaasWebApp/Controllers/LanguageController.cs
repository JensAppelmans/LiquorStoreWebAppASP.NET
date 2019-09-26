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
    public class LanguageController : SessionController
    {
        private DrankencentraleDBJensAppelmansEntities db = new DrankencentraleDBJensAppelmansEntities();

        // GET: /Language/
        public ActionResult Index()
        {
            List<LanguageViewModel> language = new List<LanguageViewModel>();
            foreach (Language p in db.Languages.OrderBy(lang => lang.Taalnaam))
                if (p.TaalId != null)
                    language.Add(new LanguageViewModel(p));
            return View(language);
            //return View(db.Languages.ToList());
        }

        // GET: /Language/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageViewModel languageVM = null;
            try
            {
                languageVM = new LanguageViewModel(db.Languages.Find(id));
            }
            catch
            {
                return Index();
            }
            return View(languageVM);

            //Language language = db.Languages.Find(id);
            //if (language == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(language);
        }

        // GET: /Language/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Language/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Taalnaam,TaalId")] Language language)
        {
            if (ModelState.IsValid)
            {
                db.Languages.Add(language);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(language);
        }

        // GET: /Language/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageViewModel languageVM = null;
            try
            {
                languageVM = new LanguageViewModel(db.Languages.Find(id));
            }
            catch
            {
                return HttpNotFound();
            }
            return View(languageVM);
            //Language language = db.Languages.Find(id);
            //if (language == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(language);
        }

        // POST: /Language/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Taalnaam,TaalId")] LanguageViewModel language)
        {
            if (ModelState.IsValid)
            {
                Language l = new Language(language); 
                db.Entry(l).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(language);
        }

        // GET: /Language/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageViewModel languageVM = null;
            try
            {
                languageVM = new LanguageViewModel(db.Languages.Find(id));
            }
            catch
            {
                return HttpNotFound();
            }
            return View(languageVM);
            //Language language = db.Languages.Find(id);
            //if (language == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(language);
        }

        // POST: /Language/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Language language = db.Languages.Find(id);
            db.Languages.Remove(language);
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
