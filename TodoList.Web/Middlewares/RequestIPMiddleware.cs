using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreMiddleware.Middlewares
{
    public class RequestIPMiddleware
    {
        private readonly RequestDelegate _next; //定义请求委托
        private readonly ILogger _logger; //定义日志

        public RequestIPMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestIPMiddleware>();
        }

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        /// <returns>Task(void)</returns>
        public async Task Invoke(HttpContext context)
        {

           
                 DateTime DateTime = DateTime.Now;
                 string ip = new StringBuilder()
                .Append(context.Request.Scheme)
                .Append("://")
                .Append(context.Request.Host)
                .Append(context.Request.PathBase)
                .Append(context.Request.Path)
                .Append(context.Request.QueryString)
                .ToString();
            _logger.LogInformation($"URL：{ip}");
            _logger.LogInformation($"DateTime：{DateTime}");
            await _next.Invoke(context);
        }
    }
}
