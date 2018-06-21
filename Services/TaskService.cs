using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using todoList.Data;

namespace todoList.Services
{
    public class TaskService : GenericService<TaskItem>, ITaskService
    {

        public TaskService(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public IEnumerable FindAll()
        {
            return ApplicationDbContext.TaskItem.Include(t => t.Category).Include(t => t.User);
        }
    }
}
