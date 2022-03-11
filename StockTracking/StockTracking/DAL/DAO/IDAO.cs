using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.DAL.DAO
{
    internal interface IDAO<T,K> where T : class where K : class
    {
        //T = clase del modelo
        //K = clase del detalle
        List<K> Select();
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool GetBack(int ID);
    }
}
