using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DateTimeCalculator_MVC_Webapp.Models;
using DateTimeCalculator_MVC_Webapp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;

namespace DateTimeCalculator_MVC_Webapp.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        private IRepository _calculationsRepository;
        private IDateCalculator _dateCalculator;
        private readonly IStringLocalizer<HomeController> _localizer;
        // private ISession _session;

        //DI
        public HomeController(ILogger<HomeController> logger, IRepository calculationsRepository, IDateCalculator dateCalculator, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _calculationsRepository = calculationsRepository;
            _dateCalculator = dateCalculator;
            _localizer = localizer;
            
            // _session = session;
        }
 
        public IActionResult Index()
        {
            if(TempData["result"]!=null)
            {
                ViewBag.result = TempData["result"].ToString();
            }

            //ViewData["Description"] = _localizer["Description"];
            //ViewData["Message"] = _localizer["App Description"];
            _logger.LogInformation(_localizer["App Description"]);
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult ChooseLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTime.Now.AddDays(2) }
                );
            return LocalRedirect(returnUrl);
        }


        [HttpPost]
        public IActionResult Calculate(InputModel model)
        {
            //adding random string to prevent session id from changing on each request
            HttpContext.Session.SetString("temp", "tempstring");
            OutputModel output = new OutputModel(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                                                    model.Date,
                                                    model.ParamDays,
                                                    model.ParamWeeks,
                                                    model.ParamMonths,
                                                    model.ParamYears,
                                                    model.Operation);
            output.Result = _dateCalculator.Calculate(model);
            output.SessionID = HttpContext.Session.Id;
            _logger.LogInformation("Session ID :" + output.SessionID);
            _calculationsRepository.AddCalculation(output);
            TempData["result"] = output.Result;
            return RedirectToAction("Index");
        }
    }
}
