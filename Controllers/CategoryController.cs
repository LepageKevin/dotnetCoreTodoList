using todoList.Data;
using todoList.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using todoList.Models;
using System.Threading.Tasks;
using System;

namespace todoList.Controllers
{
    [Route("[controller]/[action]")]
    public class CategoryController : Controller
    {

        private ICategoryService ICategoryService { get; set; }

        public CategoryController(ICategoryService iCategoryService)
        {
            this.ICategoryService = iCategoryService;
        }

        public IActionResult Create()
        {
            return View(new Category());
        }
        
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            ICategoryService.Create(category);
            return RedirectToAction(nameof(CategoryList));
        }

        public IActionResult CategoryList()
        {
            return View(ICategoryService.FindAll());
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(ICategoryService.FindById(id));
        }
        
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            ICategoryService.Delete(category.ID);
            return RedirectToAction(nameof(CategoryList));
        }
    }
}