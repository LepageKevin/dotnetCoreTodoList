using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using todoList.Data;

namespace todoList.Services
{
    public interface ICategoryService : IGenericService<Category>
    {
        IEnumerable GetCategories();
    }
}
