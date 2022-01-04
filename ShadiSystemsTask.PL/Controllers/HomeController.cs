using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShadiSystemsTask.BL.Interface;
using ShadiSystemsTask.BL.Models;
using ShadiSystemsTask.DAL.Database;
using ShadiSystemsTask.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShadiSystemsTask.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItem item;
        private readonly ICategory category;
        private readonly IMapper mapper;

        public HomeController(IItem item, IMapper mapper, ICategory category)
        {
            this.item = item;
            this.mapper = mapper;
            this.category = category;
        }
        public IActionResult Index(string Ename)
        {
            if (Ename == "" || Ename == null)
            {
                var model = item.Get();
                var data = mapper.Map<IEnumerable<ItemVM>>(model);
                return View(data);
            }
            else
            {
                var model = item.Search(Ename);

                ViewBag.found = "* No item Called " + Ename + " *";
                var data = mapper.Map<IEnumerable<ItemVM>>(model);
                return View(data);



            }
        }

        public IActionResult Create()
        {
            var CategoryModel = mapper.Map<IEnumerable<CategoryVM>>(category.Get());
            ViewBag.CategoryList = new SelectList(CategoryModel, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(ItemVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var obj = mapper.Map<Item>(model);
                    item.Create(obj);
                    return RedirectToAction("Index", "Home");
                }

                var CategoryModel = mapper.Map<IEnumerable<CategoryVM>>(category.Get());
                ViewBag.CategoryList = new SelectList(CategoryModel, "Id", "Name");
                return View();
            }
            catch (Exception ex)
            {
                var exeption = ex.Message;
                var CategoryModel = mapper.Map<IEnumerable<CategoryVM>>(category.Get());
                ViewBag.CategoryList = new SelectList(CategoryModel, "Id", "Name");
                return View();
            }
        }

        [HttpPost]
        public JsonResult GetItemByCategoryId(int categoryId = 2)
        {
            var model = item.Get(i => i.CategoryId == categoryId);
            var data = mapper.Map<IEnumerable<ItemVM>>(model);
            return Json(data);
        }

    }
}
