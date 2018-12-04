using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FDMC.App.Models;
using FDMC.Data;
using FDMC.App.Models.ViewModels;

namespace FDMC.App.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(FDMCContext context)
        {
            this.Context = context;
        }
        public FDMCContext Context { get; private set; }

        public IActionResult Index()
        {
            var cats = this.Context.Cats
                .Select(cat => new CatConciseVewModel()
                {
                    Id = cat.Id,
                    Name = cat.Name
                })
                .ToList();
            return View(cats);
        }

        //public IActionResult About()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
