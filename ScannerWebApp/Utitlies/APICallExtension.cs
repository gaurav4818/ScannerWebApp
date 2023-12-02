using Newtonsoft.Json;
using ScannerWebApp.Models;

namespace ScannerWebApp.Utitlies
{
    public class APICallExtension
    {
        public APICallExtension() { }
        public async Task<List<StockData>> APICallExtensionMethod(string url,bool isAlert = false)
        {
            List<StockData> stocks = new List<StockData>();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (content != null && !isAlert)
                    {
                        // Parse the JSON response
                        stocks = JsonConvert.DeserializeObject<List<StockData>>(content);
                    }
                }
            }
            return stocks;
        }
    }
}
