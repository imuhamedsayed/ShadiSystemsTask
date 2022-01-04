using Microsoft.EntityFrameworkCore;
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
    public class ItemRepository : IItem
    {
        TaskDbContext db;
        public ItemRepository(TaskDbContext db)
        {
            this.db = db;
        }
        public void Create(Item obj)
        {
            db.Item.Add(obj);
            db.SaveChanges();
        }

        public IEnumerable<Item> Get(Expression<Func<Item, bool>> filter = null)
        {
            var data = db.Item.Include("Category").Select(i => i);
            if (filter != null)
            {
                data = db.Item.Include("Category").Where(filter);   
            }
            return data;
        }

        public IEnumerable<Item> Search(string EName)
        {
            var data = db.Item.Include("Category").Where(i => i.Name.Contains(EName));
            return data;
        }
    }
}
