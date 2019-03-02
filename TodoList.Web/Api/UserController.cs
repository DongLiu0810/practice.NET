using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Service;
using TodoList.Web.Models;

namespace TodoList.Web.Api
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpPost]
        public int Post([FromServices]ITodoListService todoListService, [FromBody]UserDto user)
        {
            if (todoListService.check(user.Name) == false) {
                return 0;
            } else if (todoListService.Register(user.Name, user.Password) == true) {
                return 1;
            };
            return 2;
        }

        [HttpGet]
        public long Get([FromServices]ITodoListService todoListService, [FromQuery]UserDto user)
        {
            long d=todoListService.Login(user.Name, user.Password);
            HttpContext.Session.SetString("id",d.ToString());
            return d;
        }
    }
}