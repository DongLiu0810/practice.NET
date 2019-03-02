using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Web.Filters
{
    public class Loginin : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var temp = context.HttpContext.Session.GetString("id");
            if (temp == null) {
                context.HttpContext.Response.StatusCode = 200;
                context.Result = new ContentResult() { Content = "无权限" };
            }
        }
    }
}
