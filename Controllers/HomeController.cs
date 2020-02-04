using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text; 
using System.Text.Json; 
using Microsoft.AspNetCore.Mvc;
using nltk_core;
using nltk_core.Models;

namespace nltk_core.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient _client {get;set;} 

        public HomeController ()
        {
            _client = new HttpClient(); 
        }

        public IActionResult Index()
        {
            var json = JsonSerializer.Serialize( new { word_list = "This is a sentence with model XGA"}); 
            var data = new StringContent(json, Encoding.UTF8, "application/json");
 
            var response =  _client.PostAsync(Constants.url_filter, data).Result;

            ViewData["msg"] = response.Content.ReadAsStringAsync().Result;

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your about page";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
    }
}
