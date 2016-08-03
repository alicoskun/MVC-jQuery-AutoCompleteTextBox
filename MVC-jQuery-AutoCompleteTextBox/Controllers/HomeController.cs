using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_jQuery_AutoCompleteTextBox.Models;

namespace MVC_jQuery_AutoCompleteTextBox.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            CountriesEntities entity = new CountriesEntities();
            return View(entity.CountryMasters);
        }

        [HttpPost]
        public ActionResult Index(string searchTerm)
        {
            CountriesEntities entity = new CountriesEntities();
            List<CountryMaster> countries;

            if (string.IsNullOrEmpty(searchTerm))
            {
                countries = entity.CountryMasters.ToList();
            }
            else
            {
                countries = entity.CountryMasters.Where(x => x.CountryName.StartsWith(searchTerm)).ToList();
            }
            return View(countries);
        }

        public JsonResult CountryAutoComplete(string term)
        {
            CountriesEntities entity = new CountriesEntities();
            List<CountryMaster> countries;

            countries = entity.CountryMasters.Where(x => x.CountryName.StartsWith(term)).ToList();
            
            return Json(countries, JsonRequestBehavior.AllowGet);
        }
    }
}