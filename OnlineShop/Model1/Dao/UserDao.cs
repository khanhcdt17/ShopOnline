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
        public long Insert(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user.ID;
        }
        public int Login(string userName, string passWord)
        {
            var result = db.Users.FirstOrDefault(x => x.Username == userName);
            if (result!=null)
            {
                if (result.Status==false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password==passWord)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
            return 0;
            
        }
        public IEnumerable<User> ListAllPaging(int page,int pageSize)
        {
            return db.Users.OrderByDescending(x=>x.CreatedDate).ToPagedList(page,pageSize);
        }
        public User GetByUserName(string userName)
        {
            return db.Users.SingleOrDefault(x => x.Username == userName);
        }
    }
}
