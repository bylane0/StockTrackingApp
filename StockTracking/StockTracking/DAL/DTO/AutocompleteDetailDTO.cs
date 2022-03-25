using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.DAL.DTO
{
    public class AutocompleteDetailDTO
    {
        public string customerName { get; set; }
        public string categoryName { get; set; }
        public string productName { get; set; }
        public int stockAmount { get; set; }
        public int price { get; set; }
    }
}
