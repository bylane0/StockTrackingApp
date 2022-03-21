using StockTracking.DAL;
using StockTracking.DAL.DAO;
using StockTracking.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.BLL
{
    public class UserBLL : IBLL<UserDetailDTO, UserDTO>
    {
        UserDAO dao = new UserDAO();
        PermissionDAO permissiondao = new PermissionDAO();
        public bool Delete(UserDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(UserDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(UserDetailDTO entity)
        {
        
            USER user = new USER();
            user.Name = entity.UserName;
            user.Password = entity.UserPassword;
            user.PermissionType = entity.PermissionType;
            user.Email = entity.Email;
            user.PhoneNumber = entity.PhoneNumber;
            return dao.Insert(user);
        }

        public UserDTO Select()
        {
            UserDTO dto = new UserDTO();
            dto.Users = dao.Select();
            dto.Permissions = permissiondao.Select();
            return dto;
        }
        public UserDTO Select(UserDetailDTO detail)
        {
            UserDTO dto = new UserDTO();
            dto.Users = dao.Select(detail);
            return dto;
        }

     

        public bool Update(UserDetailDTO entity)
        {
            USER user = new USER();
            user.ID = entity.UserID;
            user.Name = entity.UserName;
            user.Password = entity.UserPassword;
            user.PermissionType = entity.PermissionType;
            return dao.Update(user);
        }

 

  
    }
}
