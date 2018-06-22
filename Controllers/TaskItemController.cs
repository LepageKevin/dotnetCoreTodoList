using todoList.Data;
using todoList.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using todoList.Models;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace todoList.Controllers
{
    public class TaskItemController : Controller
    {

        private ITaskItemService ITaskItemService { get; set; }

        private ICategoryService ICategoryService { get; set; }

        private UserManager<ApplicationUser> UserManager { get; set; }

        public TaskItemController(UserManager<ApplicationUser> userManager, ICategoryService iCategoryService, ITaskItemService iTaskItemService)
        {
            this.UserManager = userManager;
            this.ITaskItemService = iTaskItemService;
            this.ICategoryService = iCategoryService;
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Create()
        {
            TaskItemViewModels taskItemViewModels = new TaskItemViewModels();
            taskItemViewModels.ListCategories = ICategoryService.FindAll().Select(t => new SelectListItem() {
                Text = t.Name,
                Value = t.ID.ToString()
            }).ToList();
            return View(taskItemViewModels);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddTaskItemAsync(TaskItem taskItem)
        {
            ApplicationUser user = await UserManager.GetUserAsync(this.User);
            taskItem.User = user;
            ITaskItemService.Create(taskItem);
            return RedirectToAction(nameof(TaskList));
        }

        public IActionResult TaskList()
        {
            return View(ITaskItemService.GetTasksWithCategoryAndUser());
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(ITaskItemService.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(TaskItem taskItem)
        {
            ITaskItemService.Delete(taskItem.ID);
            return RedirectToAction(nameof(TaskList));
        }
    }
}