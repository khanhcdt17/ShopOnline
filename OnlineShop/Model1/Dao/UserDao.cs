using Model1.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class UserDao
    {
        OnlineShopDbContext db = null;
        public UserDao()
        {
            db = new OnlineShopDbContext();
        }
        public bool ChangeStatus(long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
        public long Insert(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user.ID;
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Name = entity.Name;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.Phone = entity.Phone;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = entity.ModifiedDate;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public User GetByID(int id)
        {
            return db.Users.Find(id);
        }
        public int Login(string userName, string passWord)
        {
            var result = db.Users.FirstOrDefault(x => x.Username == userName);
            if (result != null)
            {
                if (result.Status == false)
                {
                    //Tài khoản bị khóa
                    return -1;
                }
                else
                {

                    if (result.Password == passWord)
                    {
                        //đúng tên đăng nhập và mật khẩu
                        return 1;
                    }
                    else
                    {
                        // sai tên đăng nhập hoặc mật khẩu
                        return -2;
                    }
                }
            }
            // sai tên đăng nhập
            return 0;

        }
        public IEnumerable<User> ListAllPaging(string searchString,int page, int pageSize)
        {
            
            if (string.IsNullOrEmpty(searchString))
            {
                return db.Users.OrderByDescending(x => x.CreatedDate).OrderBy(x => x.ID).ToPagedList(page, pageSize);
            }
            return db.Users.Where(x => x.Username.Contains(searchString) || x.Name.Contains(searchString)).OrderBy(x=>x.ID).ToPagedList(page, pageSize);
        }
        public User GetByUserName(string userName)
        {
            return db.Users.SingleOrDefault(x => x.Username == userName);
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
