using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class CategoryDao
    {
        private OnlineShopDbContext db;
        public CategoryDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<Category> listAll()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }
    }
}
