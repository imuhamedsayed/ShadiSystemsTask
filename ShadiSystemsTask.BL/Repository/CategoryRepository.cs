using ShadiSystemsTask.BL.Interface;
using ShadiSystemsTask.DAL.Database;
using ShadiSystemsTask.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShadiSystemsTask.BL.Repository
{
  public  class CategoryRepository : ICategory
    {
        TaskDbContext db;
        public CategoryRepository(TaskDbContext db)
        {
            this.db = db;
        }


        public IEnumerable<Category> Get(Expression<Func<Category, bool>> filter = null)
        {
            var data = db.Category.Select(i => i);
            if (filter != null)
            {
                data = db.Category.Where(filter);
            }
            return data;
        }

     
    }
}
