using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PD.IDP.TestClient.Models;
using System.Diagnostics;

namespace PD.IDP.TestClient.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("TestApiClient");
            var res = await client.GetAsync("WeatherForecast");
            var content = await res.Content.ReadAsStringAsync();
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
