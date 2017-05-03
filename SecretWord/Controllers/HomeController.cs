using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecretWord.Data;
using SecretWord.Models;
using Microsoft.EntityFrameworkCore;

namespace SecretWord.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var words = db.SecretWord                
                .OrderBy(am => am.TimeStamp);
            
            return View(words);
        }

        public IActionResult AddWord()
        {


            return Redirect(@"/Home/Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
