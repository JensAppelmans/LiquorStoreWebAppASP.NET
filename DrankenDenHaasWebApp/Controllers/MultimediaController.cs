using System;
using System.IO; 
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
    public class MultimediaController : SessionController
    {
        private DrankencentraleDBJensAppelmansEntities db = new DrankencentraleDBJensAppelmansEntities();



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(MultimediaViewModel multimedia)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string fileName = Path.GetFileName(multimedia.ImageFile.FileName);
                    string relPath = "~/Afbeeldingen/" + fileName; 
                    string filePath = Path.Combine(Server.MapPath("~/Afbeeldingen"), fileName);

                    multimedia.ImagePath = filePath;

                    multimedia.ImageFile.SaveAs(filePath);

                    Multimedia mul = new Multimedia(multimedia);

                    db.Multimedias.Add(mul);
                    //db.Entry(mul).State = EntityState.Modified;
                    db.SaveChanges();

                    int id = mul.MultimediaId; 

                    //ViewBag.Message = "De foto werd succesvol bevestigd"; 
                    TempData["shortMessage"] = "De foto werd succesvol bevestigd";
                    TempData["path"] = relPath;
                    TempData["id"] = id;
                    TempData["image"] = mul; 
                    return RedirectToAction("Create", "Product", null);
                    
                }

                catch
                {
                    //ViewBag.Message = "De foto werd niet succesvol bevestigd"; 

                    TempData["shortMessage"] = "De foto werd niet bevestigd";

                }
            }
            return View(multimedia);
        }


        //    string fileName = Path.GetFileNameWithoutExtension(multimedia.ImageFile.FileName);
        //string Extension = Path.GetExtension(multimedia.ImageFile.FileName);
        //fileName = fileName + DateTime.Now.ToString("dd/MM/yyyy") + Extension;
        //multimedia.ImagePath = "~/Afbeeldingen/" + fileName;
        //string dirName = Server.MapPath("~/Afbeeldingen/");
        //    if (!Directory.Exists(dirName))
        //    {
        //        Directory.CreateDirectory(dirName);
        //    }

        //fileName = Path.Combine(Server.MapPath("~/Afbeeldingen/"), fileName);
        //multimedia.ImageFile.SaveAs(fileName);

        // GET: /Multimedia/
        public ActionResult Index()
        {
            List<MultimediaViewModel> mul = new List<MultimediaViewModel>();
            foreach (Multimedia p in db.Multimedias.OrderBy(deb => deb.MultimediaId))
                if (p.MultimediaId > 0)
                    mul.Add(new MultimediaViewModel(p));
            return View(mul);
           // return View(db.Multimedias.ToList());
        }

        // GET: /Multimedia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MultimediaViewModel mulVM = null;
            try
            {
                mulVM = new MultimediaViewModel(db.Multimedias.Find(id));
            }
            catch
            {
                return Index();
            }
            return View(mulVM);


            //Multimedia multimedia = db.Multimedias.Find(id);
            //if (multimedia == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(multimedia);
        }

        // GET: /Multimedia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Multimedia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MultimediaId,Foto")] Multimedia multimedia)
        {
            if (ModelState.IsValid)
            {
                db.Multimedias.Add(multimedia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(multimedia);
        }

        // GET: /Multimedia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultimediaViewModel mulVM = null;
            try
            {
                mulVM = new MultimediaViewModel(db.Multimedias.Find(id));
            }
            catch
            {
                return HttpNotFound();
            }
            return View(mulVM);

           
            //Multimedia multimedia = db.Multimedias.Find(id);
            //if (multimedia == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(multimedia);
        }

        // POST: /Multimedia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MultimediaId,Foto")] MultimediaViewModel multimedia)
        {
            if (ModelState.IsValid)
            {
                Multimedia mul = new Multimedia(multimedia); 
                db.Entry(mul).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(multimedia);
        }

        // GET: /Multimedia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultimediaViewModel mulVM = null;
            try
            {
                mulVM = new MultimediaViewModel(db.Multimedias.Find(id));
            }
            catch
            {
                return HttpNotFound();
            }
            return View(mulVM);
            //Multimedia multimedia = db.Multimedias.Find(id);
            //if (multimedia == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(multimedia);
        }

        // POST: /Multimedia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Multimedia multimedia = db.Multimedias.Find(id);
            db.Multimedias.Remove(multimedia);
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
