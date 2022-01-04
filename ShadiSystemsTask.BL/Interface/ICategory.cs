using ShadiSystemsTask.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShadiSystemsTask.BL.Interface
{
  public  interface ICategory
    {
        IEnumerable<Category> Get(Expression<Func<Category, bool>> filter = null);
    }
}
