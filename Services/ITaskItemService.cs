using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using todoList.Data;

namespace todoList.Services
{
    public interface ITaskItemService : IGenericService<TaskItem>
    {
        IEnumerable<TaskItem> GetTasksWithCategoryAndUser();
    }
}
