using StockTracking.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.DAL.DAO
{
    public class PermissionDAO : StockContext, IDAO<PERMISSION, PermissionDTO>
    {
        public bool Delete(PERMISSION entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(PERMISSION entity)
        {
            throw new NotImplementedException();
        }

        public List<PermissionDTO> Select()
        {
            try
            {
                List<PermissionDTO> permissions = new List<PermissionDTO>();
                var list = db.PERMISSIONs;
                foreach (var item in list)
                {
                    PermissionDTO dto = new PermissionDTO();
                    dto.ID = item.ID;
                    dto.PermissionName = item.PermissionName;
                    permissions.Add(dto);
                }
                return permissions;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(PERMISSION entity)
        {
            throw new NotImplementedException();
        }
    }
}
