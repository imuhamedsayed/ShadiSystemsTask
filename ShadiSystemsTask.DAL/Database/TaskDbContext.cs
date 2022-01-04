using Microsoft.EntityFrameworkCore;
using ShadiSystemsTask.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadiSystemsTask.DAL.Database
{
   public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions option) : base(option)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Item> Item { get; set; }
    }
}
