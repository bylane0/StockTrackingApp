using StockTracking.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracking.DAL;

namespace StockTracking.DAL.DAO
{
    public class AutocompleteDAO : StockContext
    {
        public bool Insert(AutocompleteDetailDTO entity)
        {
            try
            {
                db.GenerateRandomData(entity.customerName, entity.categoryName, entity.productName, entity.stockAmount, entity.price);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
