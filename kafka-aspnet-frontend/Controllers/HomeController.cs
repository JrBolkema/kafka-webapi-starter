using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using kafka_aspnet_frontend.Models;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace kafka_aspnet_frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationModel model)
        {
            var response = await SendData(model);
            ViewBag.Message = response;
            return View(model);
        }

        Task<string> SendData(UserRegistrationModel model)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9090");

            string message = JsonConvert.SerializeObject(model);
            var response = client.PostAsync("/api/user-registration", new StringContent(message, Encoding.UTF8, "application/json")).Result;
            return response.Content.ReadAsStringAsync();
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
