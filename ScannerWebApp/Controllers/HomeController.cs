using HtmlAgilityPack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using ScannerWebApp.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ScannerWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public async Task<IActionResult> IndexAsync()
        {
            string url = "https://chartink.com/screener/process";
            // Set the request parameters
            var condition = new
            {
                scan_clause = "( {33489} ( latest volume >= 100000 and latest close >= 50 and latest close >= latest ema( latest close , 21 ) and latest close >= 1 day ago close and latest close - 1 candle ago close / 1 candle ago close * 100 <= 5 and ( latest high - latest close ) / ( latest high - latest low ) <= 0.5 and latest ema( latest close , 9 ) >= latest ema( latest close , 21 ) ) ) "
            };
            // Serialize the condition to JSON
            string conditionJson = JsonConvert.SerializeObject(condition);
            var contentdemo = new StringContent(conditionJson, Encoding.UTF8, "application/json");
            // Create an HttpClient
            using (var httpClient = new HttpClient())
            {
                //Perform the initial GET request to obtain the CSRF token
                var response = await httpClient.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();

                //Use HtmlAgilityPack to parse the HTML content and extract the CSRF token
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(content);
                var csrfToken = htmlDocument.DocumentNode.SelectSingleNode("//meta[@name='csrf-token']").GetAttributeValue("content", "");

                //Set the CSRF token in the request headers
                httpClient.DefaultRequestHeaders.Add("x-csrf-token", csrfToken);
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

                // Perform the POST request with the condition data
                var postResponse = await httpClient.PostAsJsonAsync(url,contentdemo);
                if (postResponse.IsSuccessStatusCode)
                {
                    var result = await postResponse.Content.ReadAsStringAsync();

                    // Parse the JSON response
                    //var stockList = JsonConvert.DeserializeObject<List<StockData>>(result);
                }
                return View();
            }

        }
        [Authorize]
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