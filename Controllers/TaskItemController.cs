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
    public class TaskItemController : Controller
    {

        private ITaskService ITaskService { get; set; }

        private UserManager<ApplicationUser> UserManager { get; set; }
        //taskService dependances dans construct
        //file controlleur pour le form
        //et un controllur pour la vue
        //dans le controlleur implementer lee itaskService

        public TaskItemController(UserManager<ApplicationUser> userManager, ITaskService iTaskService)
        {
            this.UserManager = userManager;
            this.ITaskService = iTaskService;
        }

        public IActionResult Create()
        {
            return View(new TaskItem());
        }
        
        [HttpPost]
        public async Task<IActionResult> AddTaskItemAsync(TaskItem taskItem)
        {
            ApplicationUser user = await UserManager.GetUserAsync(this.User);
            taskItem.User = user;
            taskItem.Category = new Category(){
                Name = "Lavri"
            };
            ITaskService.Create(taskItem);
            return RedirectToAction(nameof(TaskList));
        }

        public IActionResult TaskList()
        {
            return View(ITaskService.GetTasksWithCategoryAndUser());
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(ITaskService.FindById(id));
        }
        
        [HttpPost]
        public IActionResult Delete(TaskItem taskItem)
        {
            ITaskService.Delete(taskItem.ID);
            return RedirectToAction(nameof(TaskList));
        }
    }
}