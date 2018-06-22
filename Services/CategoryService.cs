using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using todoList.Data;

namespace todoList.Services
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {

        public CategoryService(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public IEnumerable GetCategories()
        {
            return this.FindAll();
        }
    }
}
