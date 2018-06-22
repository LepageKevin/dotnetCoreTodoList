using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todoList.Data;
using todoList.Services;

namespace todoList.Controllers
{
    [Route("api/tasks")]
    public class TaskItemApiController : ControllerBase
    {
        private ITaskItemService ITaskItemService { get; set; }

        public TaskItemApiController(ITaskItemService iTaskItemService)
        {
            this.ITaskItemService = iTaskItemService;
        }

        // GET api/tasks
        [HttpGet]
        public IEnumerable<TaskItem> Get()
        {
            return ITaskItemService.FindAll();
        }

        // GET api/tasks/full
        [HttpGet("full")]
        public IEnumerable<TaskItem> GetEager()
        {
            return ITaskItemService.GetTasksWithCategoryAndUser();
        }

        // GET api/tasks/5
        [HttpGet("{id}")]
        public TaskItem Get(int id)
        {
            return ITaskItemService.FindById(id);
        }

        // POST api/tasks
        [HttpPost]
        public void Post([FromBody]TaskItem taskItem)
        {
            ITaskItemService.Create(taskItem);
        }

        // PUT api/tasks/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TaskItem taskItem)
        {
        }
    }
}
