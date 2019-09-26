using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DrankenDenHaasWebApp.Translations; 

namespace DrankenDenHaasWebApp.Controllers
{
    public class HomeController : SessionController
    {
       private DrankencentraleDBJensAppelmansEntities db = new DrankencentraleDBJensAppelmansEntities();

        // GET: /Product/
        public ActionResult Index()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            foreach (Product p in db.Products.Include(p => p.Category).Include(p => p.Producer).OrderBy(p => p.Category.Categorienaam))
                if (p.ProductId > 0)
                    products.Add(new ProductViewModel(p));
            return View(products); 
            //var products = db.Products.Include(p => p.Category).Include(p => p.Producer);
            //return View(products.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Pagina nog in opmaak";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = Texts.FindUs; 

            return View();
        }

        public ActionResult ChangeLanguage(string id)       // Wordt opgeroepen als een taal gekozen werd in het menu
        {
            Language language = Language.LanguageDictionary[id];
            Session["Language"] = language;                 // Bewaar de taal met de gekozen Id in Session
            ViewBag.LanguageName = language.Taalnaam;           // Zorg dat de nieuwe taal ook aan de pagina wordt doorgegeven
            ViewBag.LanguageId = language.TaalId;
            return Redirect(Session["LastUrl"].ToString());
        }
    }
}