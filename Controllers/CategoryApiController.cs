using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todoList.Data;
using todoList.Services;

namespace todoList.Controllers
{
    [Route("api/category")]
    public class CategoryApiController : ControllerBase
    {
        private ICategoryService ICategoryService { get; set; }

        public CategoryApiController(ICategoryService iCategoryService)
        {
            this.ICategoryService = iCategoryService;
        }

        // GET api/category
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return ICategoryService.FindAll();
        }

        // GET api/category/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return ICategoryService.FindById(id);
        }

        // POST api/category
        [HttpPost]
        public void Post([FromBody]Category category)
        {
            ICategoryService.Create(category);
        }

        // PUT api/category/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Category category)
        {
        }
    }
}
