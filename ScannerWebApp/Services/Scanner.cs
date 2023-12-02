using Newtonsoft.Json;
using ScannerWebApp.IServices;
using ScannerWebApp.Models;
using ScannerWebApp.Utitlies;

namespace ScannerWebApp.Services
{
    public class Scanner : IScanner
    {
        public Scanner() { }
        APICallExtension aPICallExtension = new APICallExtension();
        public async Task<List<StockData>> GetDojiStocks()
        {
            string url = "https://flaskapp1234.azurewebsites.net/api/DojiSwingStocks";
            var stocks = await aPICallExtension.APICallExtensionMethod(url);
            return stocks;
        }

        public async Task<List<StockData>> GetFiftyTwoWeeksHighStocks()
        {
            string url = "https://flaskapp1234.azurewebsites.net/api/FiftyTwoWeekHigh";

            var stocks = await aPICallExtension.APICallExtensionMethod(url);
            return stocks;
        }

        public async Task<List<StockData>> GetHighPowerSwingStocks()
        {
            string url = "https://flaskapp1234.azurewebsites.net/api/TurtleSwingStocks";
            var stocks = await aPICallExtension.APICallExtensionMethod(url);
            return stocks;
        }

        public async Task<List<StockData>> GetIntradayBoostStocks()
        {
            string url = "https://flaskapp1234.azurewebsites.net/api/IntradayBoost";
            var stocks = await aPICallExtension.APICallExtensionMethod(url);
            return stocks;
        }

        public async Task<List<StockData>> GetLongStocksDayAgo()
        {
            string url = "https://flaskapp1234.azurewebsites.net/api/LongStockOneDayAgo";
            var stocks = await aPICallExtension.APICallExtensionMethod(url);
            return stocks;
        }

        public async Task<List<StockData>> GetLongStocksIntradayLive()
        {
            string url = "https://flaskapp1234.azurewebsites.net/api/LongStockLiveIntraday";
            var stocks = await aPICallExtension.APICallExtensionMethod(url);
            //var stock = string.Join(",", stocks.Select(x => x.NseCode));
            //string sendMsg = $"https://flaskapp1234.azurewebsites.net/api/SendTelegramAlert/{stock}";
            //var demo = await aPICallExtension.APICallExtensionMethod(sendMsg, true);
            return stocks;
        }

        public async Task<List<StockData>> GetPoleAndFlagStocks()
        {
            string url = "https://flaskapp1234.azurewebsites.net/api/PoleAndFlagStock";
            var stocks = await aPICallExtension.APICallExtensionMethod(url);
            return stocks;
        }

        public async Task<List<StockData>> GetRocketIntradayBearishStocks()
        {
            string url = "https://flaskapp1234.azurewebsites.net/api/RocketIntradayBearish";
            var stocks = await aPICallExtension.APICallExtensionMethod(url);
            return stocks;
        }

        public async Task<List<StockData>> GetRocketIntradayBullishStocks()
        {
            string url = "https://flaskapp1234.azurewebsites.net/api/RocketIntradayBullish";
            var stocks = await aPICallExtension.APICallExtensionMethod(url);
            return stocks;
        }

        public async Task<List<StockData>> GetshortStocksDayAgo()
        {
            string url = "https://flaskapp1234.azurewebsites.net/api/ShortStockOneDayAgo";
            var stocks = await aPICallExtension.APICallExtensionMethod(url);
            return stocks;
        }
        public async Task<List<StockData>> GetshortStocksIntradayLive()
        {
            string url = "https://flaskapp1234.azurewebsites.net/api/ShortStockLiveIntraday";
            var stocks = await aPICallExtension.APICallExtensionMethod(url);
            return stocks;
        }

        public async Task<List<StockData>> GetSwingStocks()
        {
            string url = "https://flaskapp1234.azurewebsites.net/api/SwingStockScanner";
            var stocks = await aPICallExtension.APICallExtensionMethod(url);
            return stocks;
        }

        public async Task<List<StockData>> GetVCPStocks()
        {
            string url = "https://flaskapp1234.azurewebsites.net/api/ATRSwingStocks";
            var stocks = await aPICallExtension.APICallExtensionMethod(url);
            return stocks;
        }

        public async Task<List<StockData>> GetVolumeBreakoutStocksIntraday()
        {
            string url = "https://flaskapp1234.azurewebsites.net/api/VolumeBreakout";
            var stocks = await aPICallExtension.APICallExtensionMethod(url);
            return stocks;
        }
        public async Task<List<StockData>> GetThirtyDaysConsolidation()
        {
            string url = "https://flaskapp1234.azurewebsites.net/api/ThirtyDaysConsolidation";
            var stocks = await aPICallExtension.APICallExtensionMethod(url);
            return stocks;
        }
        public async Task<List<StockData>> GetTodaysHighMoveStocks()
        {
            string url = "https://flaskapp1234.azurewebsites.net/api/TodaysHighMoveStocks";
            var stocks = await aPICallExtension.APICallExtensionMethod(url);
            return stocks;
        }
    }
}
