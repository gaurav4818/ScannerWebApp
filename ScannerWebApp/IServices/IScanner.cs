using Microsoft.AspNetCore.Mvc;
using ScannerWebApp.Models;

namespace ScannerWebApp.IServices
{
    public interface IScanner
    {
       Task<List<StockData>> GetLongStocksDayAgo();
       Task<List<StockData>> GetshortStocksDayAgo();
       Task<List<StockData>> GetLongStocksIntradayLive();
       Task<List<StockData>> GetSwingStocks();
       Task<List<StockData>> GetVolumeBreakoutStocksIntraday();
       Task<List<StockData>> GetIntradayBoostStocks();
       Task<List<StockData>> GetFiftyTwoWeeksHighStocks();
       Task<List<StockData>> GetPoleAndFlagStocks();
       Task<List<StockData>> GetVCPStocks();
       Task<List<StockData>> GetDojiStocks();
       Task<List<StockData>> GetHighPowerSwingStocks();
       Task<List<StockData>> GetRocketIntradayBullishStocks();
       Task<List<StockData>> GetRocketIntradayBearishStocks();
       Task<List<StockData>> GetThirtyDaysConsolidation();
       Task<List<StockData>> GetTodaysHighMoveStocks();
    }
}
