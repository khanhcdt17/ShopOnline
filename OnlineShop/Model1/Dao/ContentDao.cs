using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class ContentDao
    {
        private OnlineShopDbContext db;
        public ContentDao()
        {
            db = new OnlineShopDbContext();
        }
        public Content GetById(long id)
        {
            return db.Contents.Find(id);
        }
    }
}
