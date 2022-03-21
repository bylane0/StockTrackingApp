
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
                                permissionName = p.PermissionName,
                                email = u.Email,
                                phone = u.PhoneNumber

                            }).ToList();

                foreach (var item in list)
                {
                    UserDetailDTO dto = new UserDetailDTO
                    {
                        UserID = item.userID,
                        UserName = item.userName,
                        UserPassword = item.userPassword,
                        PermissionType = item.permissionID,
                        PermissionName = item.permissionName,
                        Email = item.email,
                        PhoneNumber = item.phone
                    };
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
                                permissionName = p.PermissionName,
                                email = u.Email,
                                phone = u.PhoneNumber

                            }).ToList();

                foreach (var item in list)
                {
                    UserDetailDTO dto = new UserDetailDTO
                    {
                        UserID = item.userID,
                        UserName = item.userName,
                        UserPassword = item.userPassword,
                        PermissionType = item.permissionID,
                        PermissionName = item.permissionName,
                        Email = item.email,
                        PhoneNumber = item.phone
                    };

                    users.Add(dto);
                }
                return users;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public bool Update(USER entity)
        {
            try
            {
                USER user = db.USERs.First(x => x.ID == entity.ID);
                user.Name = entity.Name;
                user.Password = entity.Password;
                user.PermissionType = entity.PermissionType;

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
