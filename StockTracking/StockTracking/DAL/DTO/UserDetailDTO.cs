using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.DAL.DTO
{
    public class UserDetailDTO
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int PermissionType { get; set; }
        public string PermissionName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
