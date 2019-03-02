using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoList.Repository.Entity;
using TodoList.Service;
using TodoList.Web.Filters;
using TodoList.Web.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoList.Web.Api
{
    //[Loginin]
    [Route("api/[controller]")]
    public class TodoListController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Todo> Get([FromServices]ITodoListService todoListService, [FromQuery]long id)
        {
            return todoListService.GetTodoList(id);
        }

        // GET api/<controller>/5
        [HttpPost]
        [Route("add")]
        public bool Add([FromServices]ITodoListService todoListService, [FromBody]Add add)
        {
            return todoListService.add(add.userid, add.title);
        }
        // POST api/<controller>
        [HttpPost]
        [Route("delete")]
        public bool Delete([FromServices]ITodoListService todoListService, [FromBody]TodoDto todos)
        {
            return todoListService.delate(todos.id);
        }
        
    }
}
