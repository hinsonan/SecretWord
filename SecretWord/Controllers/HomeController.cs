using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecretWord.Data;
using SecretWord.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SecretWord.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> user;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userman)
        {
            db = context;
            user = userman;
        }
        public IActionResult Index()
        {
            var word = db.SecretWord                
                .OrderByDescending(am => am.TimeStamp).First();
            
            return View(word);
        }

        public IActionResult AddWord()
        {
            SecretWordModel newWord = new SecretWordModel();
            newWord.TimeStamp = DateTime.Now;
            newWord.Username = User.Identity.Name;
            // newWord.Word = 

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
