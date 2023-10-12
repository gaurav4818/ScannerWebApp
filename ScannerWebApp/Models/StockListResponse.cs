namespace ScannerWebApp.Models
{
 
   public class StockData
    {
       public string BseCode { get; set; }
       public string NseCode { get; set; }
        public decimal Close { get; set; }
        public string Name { get; set; }
        public decimal per_chg { get; set; }
        public int sr { get; set; }
        public int volume { get; set; }

    }

    public class PaginatedItemsViewModel
    {
        public List<StockData> stockDatas { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}
