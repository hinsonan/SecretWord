using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecretWord.Data;
using SecretWord.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace SecretWord.Controllers
{
    [Authorize]
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

        public IActionResult AddWord(string SecretWord)
        {
            SecretWordModel newWord = new SecretWordModel();
            newWord.TimeStamp = DateTime.Now;
            newWord.Username = User.Identity.Name;
            newWord.Word = SecretWord;
            db.SecretWord.Add(newWord);
            db.SaveChanges();

            return Redirect(@"/Home/Index");
        }
        public IActionResult Words()
        {
            var allWords = db.SecretWord.OrderByDescending(am => am.TimeStamp);
            return View(allWords);
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
