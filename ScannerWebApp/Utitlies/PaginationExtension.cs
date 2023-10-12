using Microsoft.AspNetCore.Mvc.RazorPages;
using ScannerWebApp.Models;

namespace ScannerWebApp.Utitlies
{
    public class PaginationExtension
    {
        public PaginationExtension() { }

        public PaginatedItemsViewModel PaginationExtensionMethod(List<StockData> stocks, int page, int pageSize)
        {
            var totalItems = stocks.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            var paginatedItems = stocks.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var model = new PaginatedItemsViewModel
            {
                stockDatas = paginatedItems,
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages
            };

            return model;
        }
    }
}
