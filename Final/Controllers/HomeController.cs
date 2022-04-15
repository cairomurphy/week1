using Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Controllers
{
    public class HomeController : Controller
    {
        private IQuoteRepository repo { get; set; }

        public HomeController(IQuoteRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index()
        {
            var x = repo.Quotes.OrderBy(x => x.Author).ToList();

            return View(x);
        }

        public IActionResult RandomQuote()
        {
            Random rand = new Random();
            var quote = repo.Quotes.ToList();

            var x = rand.Next(quote.Count);
            return View(quote[x]);
        }

        [HttpGet]
        public IActionResult AddQuote()
        {
            
            return View(new AddedQuote());
        }

        [HttpPost]
        public IActionResult AddQuote(AddedQuote q)
        {
            if (ModelState.IsValid)
            {
                repo.CreateQuote(q);
                repo.SaveQuote(q);
                return View("Index", repo.Quotes.ToList());
            }
            else
            {
             
                return View(q);
            }

        }

        [HttpGet]
        public IActionResult Details(int QuoteID)
        {


            var q = repo.Quotes.Single(x => x.QuoteId == QuoteID);

            return View("Details", q);
        }

        [HttpPost]
        public IActionResult Details(AddedQuote q)
        {
            repo.UpdateQuote(q);
            repo.SaveQuote(q);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int QuoteID)
        {
   

            var q = repo.Quotes.Single(x => x.QuoteId == QuoteID);

            return View("AddQuote", q);
        }

        [HttpPost]
        public IActionResult Edit(AddedQuote q)
        {
            repo.UpdateQuote(q);
            repo.SaveQuote(q);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int quoteid)
        {
            var q = repo.Quotes.Single(x => x.QuoteId == quoteid);

            return View(q);
        }

        [HttpPost]
        public IActionResult Delete(AddedQuote q)
        {
            repo.DeleteQuote(q);
            repo.SaveQuote(q);
            return RedirectToAction("Index", repo.Quotes.ToList());
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
    }
}
