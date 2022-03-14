using StockTracking.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.DAL.DAO
{
    public class UserDAO : StockContext, IDAO<USER, UserDetailDTO>
    {
        public bool Delete(SALE entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(USER entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(USER entity)
        {
            try
            {
                db.USERs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<UserDetailDTO> Select(UserDetailDTO detail)
        {
            try
            {
                List<UserDetailDTO> users = new List<UserDetailDTO>();
                var list = (from u in db.USERs.Where(x => x.Name == detail.UserName && x.Password == detail.UserPassword)
                            join p in db.PERMISSIONs on u.PermissionType equals p.ID     
                            select new
                            {
                                userID = u.ID,
                                userName = u.Name,
                                userPassword = u.Password,
                                permissionID = u.PermissionType,
                                permissionName = p.PermissionName
                                
                            }).ToList();

                foreach (var item in list)
                {
                    UserDetailDTO dto = new UserDetailDTO();
                    dto.UserID = item.userID;
                    dto.UserName = item.userName;
                    dto.UserPassword = item.userPassword;
                    dto.PermissionType = item.permissionID;
                    dto.PermissionName = item.permissionName;

                    users.Add(dto);
                }
                return users;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<UserDetailDTO> Select()
        {
            try
            {
                List<UserDetailDTO> users = new List<UserDetailDTO>();
                var list = (from u in db.USERs
                            join p in db.PERMISSIONs on u.PermissionType equals p.ID
                            select new
                            {
                                userID = u.ID,
                                userName = u.Name,
                                userPassword = u.Password,
                                permissionID = u.PermissionType,
                                permissionName = p.PermissionName

                            }).ToList();

                foreach (var item in list)
                {
                    UserDetailDTO dto = new UserDetailDTO();
                    dto.UserID = item.userID;
                    dto.UserName = item.userName;
                    dto.UserPassword = item.userPassword;
                    dto.PermissionType = item.permissionID;
                    dto.PermissionName = item.permissionName;

                    users.Add(dto);
                }
                return users;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(SALE entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(USER entity)
        {
            throw new NotImplementedException();
        }
    }
}
