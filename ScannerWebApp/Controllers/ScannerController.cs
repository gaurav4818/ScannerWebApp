using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ScannerWebApp.Models;
using ScannerWebApp.IServices;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScannerWebApp.Utitlies;
using Microsoft.AspNetCore.Authorization;

namespace ScannerWebApp.Controllers
{
    [Authorize]
    public class ScannerController : Controller
    {
        private readonly IScanner _scanner;
        private readonly PaginationExtension paginationExtension;
        public ScannerController(IScanner scanner) {
            this._scanner = scanner;
            paginationExtension = new PaginationExtension();
        }
        public  IActionResult IndexAsync()
        {
            return View();
        }
        public async Task<IActionResult> GetDojiStocksAsync(int page = 1, int pageSize = 10)
        {
            var stocks = await _scanner.GetDojiStocks();
            string actionName = ControllerContext.ActionDescriptor.ActionName;
            var model = paginationExtension.PaginationExtensionMethod(stocks,page,pageSize);
            ViewBag.ActionName = actionName;

            ViewBag.DynamicTitle = "Doji";
            return View("scanner", model);
        }
        public async Task<IActionResult> GetFiftyTwoWeeksHighStocksAsync(int page = 1, int pageSize = 10)
        {
            var stocks = await _scanner.GetFiftyTwoWeeksHighStocks();
            string actionName = ControllerContext.ActionDescriptor.ActionName;
            var model = paginationExtension.PaginationExtensionMethod(stocks, page, pageSize);
            ViewBag.ActionName = actionName;

            ViewBag.DynamicTitle = "52 Week High";
            return View("scanner", model);
        }
        public async Task<IActionResult> GetHighPowerSwingStocksAsync(int page = 1, int pageSize = 10)
        {
            var stocks = await _scanner.GetHighPowerSwingStocks();
            string actionName = ControllerContext.ActionDescriptor.ActionName;
            var model = paginationExtension.PaginationExtensionMethod(stocks, page, pageSize);
            ViewBag.ActionName = actionName;

            ViewBag.DynamicTitle = "High Power Swing";
            return View("scanner", model);
        }
        public async Task<IActionResult> GetIntradayBoostStocksAsync(int page = 1, int pageSize = 10)
        {
            var stocks = await _scanner.GetIntradayBoostStocks();
            string actionName = ControllerContext.ActionDescriptor.ActionName;
            var model = paginationExtension.PaginationExtensionMethod(stocks, page, pageSize);
            ViewBag.ActionName = actionName;

            ViewBag.DynamicTitle = "Intraday Boost";
            return View("scanner", model);
        }
        public async Task<IActionResult> AnalysisBullishScannerAsync(int page = 1, int pageSize = 10)
        {
            var stocks = await _scanner.GetLongStocksDayAgo();
            string actionName = ControllerContext.ActionDescriptor.ActionName;
            var model = paginationExtension.PaginationExtensionMethod(stocks, page, pageSize);
            ViewBag.ActionName = actionName;

            ViewBag.DynamicTitle = "Intraday Bullish Scanner";
            return View("scanner", model);
        }
        public async Task<IActionResult> ExecutionBullishScreenerAsync(int page = 1, int pageSize = 10)
        {
            var stocks = await _scanner.GetLongStocksIntradayLive();
            string actionName = ControllerContext.ActionDescriptor.ActionName;
            var model = paginationExtension.PaginationExtensionMethod(stocks, page, pageSize);
            ViewBag.ActionName = actionName;

            ViewBag.DynamicTitle = "Intraday Live Bullish Scanner";
            return View("scanner", model);
        }
        public async Task<IActionResult> AnalysisBearishScannerAsync(int page = 1, int pageSize = 10)
        {
            var stocks = await _scanner.GetshortStocksDayAgo();
            string actionName = ControllerContext.ActionDescriptor.ActionName;
            var model = paginationExtension.PaginationExtensionMethod(stocks, page, pageSize);
            ViewBag.ActionName = actionName;

            ViewBag.DynamicTitle = "Intraday Bearish Scanner";
            return View("scanner", model);
        }
        public async Task<IActionResult> ExecutionBearishScreenerAsync(int page = 1, int pageSize = 10)
        {
            var stocks = await _scanner.GetshortStocksIntradayLive();
            string actionName = ControllerContext.ActionDescriptor.ActionName;
            var model = paginationExtension.PaginationExtensionMethod(stocks, page, pageSize);
            ViewBag.ActionName = actionName;

            ViewBag.DynamicTitle = "Intraday Live Bearish Scanner";
            return View("scanner", model);
        }
        public async Task<IActionResult> GetPoleAndFlagStocksAsync(int page = 1, int pageSize = 10)
        {
            var stocks = await _scanner.GetPoleAndFlagStocks();
            string actionName = ControllerContext.ActionDescriptor.ActionName;
            var model = paginationExtension.PaginationExtensionMethod(stocks, page, pageSize);
            ViewBag.ActionName = actionName;

            ViewBag.DynamicTitle = "Pole And Flag";
            return View("scanner", model);
        }
        public async Task<IActionResult> GetRocketIntradayBullishStocksAsync(int page = 1, int pageSize = 10)
        {
            var stocks = await _scanner.GetRocketIntradayBullishStocks();
            string actionName = ControllerContext.ActionDescriptor.ActionName;
            var model = paginationExtension.PaginationExtensionMethod(stocks, page, pageSize);
            ViewBag.ActionName = actionName;

            ViewBag.DynamicTitle = "Intraday Rocket Bullish";
            return View("scanner", model);
        }
        public async Task<IActionResult> GetRocketIntradayBearishStocksAsync(int page = 1, int pageSize = 10)
        {
            var stocks = await _scanner.GetRocketIntradayBearishStocks();
            string actionName = ControllerContext.ActionDescriptor.ActionName;
            var model = paginationExtension.PaginationExtensionMethod(stocks, page, pageSize);
            ViewBag.ActionName = actionName;

            ViewBag.DynamicTitle = "Intraday Rocket Bearish";
            return View("scanner", model);
        }
        public async Task<IActionResult> GetSwingStocksAsync(int page = 1, int pageSize = 10)
        {
            var stocks = await _scanner.GetSwingStocks();
            string actionName = ControllerContext.ActionDescriptor.ActionName;
            var model = paginationExtension.PaginationExtensionMethod(stocks, page, pageSize);
            ViewBag.ActionName = actionName;

            ViewBag.DynamicTitle = "Swing";
            return View("scanner", model);
        }
        public async Task<IActionResult> GetVCPStocksAsync(int page = 1, int pageSize = 10)
        {
            var stocks = await _scanner.GetVCPStocks();
            string actionName = ControllerContext.ActionDescriptor.ActionName;
            var model = paginationExtension.PaginationExtensionMethod(stocks, page, pageSize);
            ViewBag.ActionName = actionName;

            ViewBag.DynamicTitle = "VCP";
            return View("scanner", model);
        }
        public async Task<IActionResult> GetVolumeBreakoutStocksIntradayAsync(int page = 1, int pageSize = 10)
        {
            var stocks = await _scanner.GetVolumeBreakoutStocksIntraday();
            string actionName = ControllerContext.ActionDescriptor.ActionName;
            var model = paginationExtension.PaginationExtensionMethod(stocks, page, pageSize);
            ViewBag.ActionName = actionName;

            ViewBag.DynamicTitle = "Volume Breakout Intraday";
            return View("scanner", model);
        }
        public async Task<IActionResult> GetTodaysHighMoveStocksAsync(int page = 1, int pageSize = 10)
        {
            var stocks = await _scanner.GetTodaysHighMoveStocks();
            string actionName = ControllerContext.ActionDescriptor.ActionName;
            var model = paginationExtension.PaginationExtensionMethod(stocks, page, pageSize);
            ViewBag.ActionName = actionName;

            ViewBag.DynamicTitle = "Intraday High Moves";
            return View("scanner", model);
        }
        public async Task<IActionResult> GetThirtyDaysConsolidationAsync(int page = 1, int pageSize = 10)
        {
            var stocks = await _scanner.GetThirtyDaysConsolidation();
            string actionName = ControllerContext.ActionDescriptor.ActionName;
            var model = paginationExtension.PaginationExtensionMethod(stocks, page, pageSize);
            ViewBag.ActionName = actionName;

            ViewBag.DynamicTitle = "30 Days Consolidation";
            return View("scanner", model);
        }
    }
}
