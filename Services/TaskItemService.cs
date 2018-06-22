using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using todoList.Data;

namespace todoList.Services
{
    public class TaskItemService : GenericService<TaskItem>, ITaskItemService
    {

        public TaskItemService(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public IEnumerable<TaskItem> GetTasksWithCategoryAndUser()
        {
            return this.FindAllIncluable().Include(t => t.Category).Include(t => t.User);
        }
    }
}
