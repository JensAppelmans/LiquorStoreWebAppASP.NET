

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace DrankenDenHaasWebApp.Controllers
{
    public class SessionController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            if (Session["Culture"] == null)       // Initialize the session if the session has not been used yet 
            {
                String culturestring = HttpContext.Request.UserLanguages[0]; // Get the current browser culture
                Session["Culture"] = new CultureInfo(culturestring);
                Session["Language"] = Language.LanguageDictionary[culturestring.Substring(0, 2)];
                Session["Url"] = HttpContext.Request.Url.AbsoluteUri;        // Get the current Url
            }

            CultureInfo culture = (CultureInfo)Session["Culture"];           // Get the applied cultureinfo
            string cultureId = culture.ToString();
            Language language = (Language)Session["Language"];               // Get the language (that maybe just changed)
            if (language.TaalId != cultureId.Substring(0, 2))                     // The language just changed !
            {
                cultureId = HttpContext.Request.UserLanguages[0];
                string keyboard = cultureId.Substring(2, cultureId.Length - 2);
                try
                {
                    Session["Culture"] = culture = new CultureInfo(language.TaalId + keyboard);
                }
                catch
                {
                    Session["Culture"] = culture = new CultureInfo(language.TaalId);
                }
            }

            // Apply the current culture
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture = culture;

            // Make sure the Session has the correct values
            Session["LastUrl"] = Session["Url"].ToString();
            Session["Url"] = HttpContext.Request.Url.AbsoluteUri;
            ViewBag.LanguageName = language.Taalnaam;                    // Zorg dat de huidige taalnaam altijd aan de pagina wordt doorgegeven
            ViewBag.LanguageId = language.TaalId;

            //Session winkelmandje
            //if (Session["Winkelmand"] == null)
            //{
            //    Session["Winkelmand"] = new 
            //}




            // Zorg dat de originele BeginExecuteCore alsnog uitgevoerd wordt
            return base.BeginExecuteCore(callback, state);          // Execute default BeginExecuteCore    




          

        }
    }
}