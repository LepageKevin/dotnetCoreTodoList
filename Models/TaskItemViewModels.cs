using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using todoList.Data;
using todoList.Models;

namespace todoList.Models
{
    public class TaskItemViewModels
    {
        public int ID { get; set; }

        public todoList.Data.TaskItem.StateType State { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }
        
        public int CategoryId { get; set; }
        
        public ApplicationUser User { get; set; }
        
        public List<SelectListItem> ListCategories { get; set; }
    }
}