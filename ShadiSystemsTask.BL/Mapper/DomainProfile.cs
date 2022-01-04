using AutoMapper;
using ShadiSystemsTask.BL.Models;
using ShadiSystemsTask.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadiSystemsTask.BL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Item, ItemVM>();
            CreateMap<ItemVM, Item>();

            CreateMap<Category, CategoryVM>();
            CreateMap<CategoryVM, Category>();
        }
     
    }
}
