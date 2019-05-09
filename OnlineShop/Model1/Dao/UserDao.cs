using Model1.EF;
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
        public bool Login(string userName, string passWord)
        {
            var result = db.Users.Count(x => x.Username == userName && x.Password == passWord);
            return (result > 0);
            
        }
        public User GetByUserName(string userName)
        {
            return db.Users.SingleOrDefault(x => x.Username == userName);
        }
    }
}
