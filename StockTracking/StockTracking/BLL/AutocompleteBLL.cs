using StockTracking.DAL.DAO;
using StockTracking.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.BLL
{
    public class AutocompleteBLL : IBLL<AutocompleteDetailDTO, AutocompleteDTO>
    {
        AutocompleteDAO dao = new AutocompleteDAO();
        public bool Delete(AutocompleteDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(AutocompleteDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(AutocompleteDetailDTO entity)
        {
            return dao.Insert(entity);
        }

        public AutocompleteDTO Select()
        {
            throw new NotImplementedException();
        }

        public bool Update(AutocompleteDetailDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
