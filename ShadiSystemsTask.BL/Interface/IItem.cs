using ShadiSystemsTask.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShadiSystemsTask.BL.Interface
{
  public  interface IItem
    {
        IEnumerable<Item> Get(Expression<Func<Item, bool>> filter = null);
        void Create(Item obj);
        IEnumerable<Item> Search(String EName);
    }
}
