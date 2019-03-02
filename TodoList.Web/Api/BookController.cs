using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Myth.SIS.BurialPoint.Api.DbContent;
using TodoList.Repository;
using TodoList.Service;
using TodoList.Service.Dto;
using TodoList.Service.Impl;

namespace Myth.SIS.BurialPoint.Api.Controllers
{
    /// <summary>
    /// 书籍的webapi
    /// </summary>
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {

        [HttpGet("remove")]
        public bool Remove([FromServices]IBookService bookService, [FromQuery]long id) {

            return bookService.remove(id);
        }

        [HttpPost("add")]
        public bool Add([FromServices]IBookService bookService, [FromBody]adds add)
        {

            return bookService.Add(add);
        }
        [HttpPost("update")]
        public bool Update([FromServices]IBookService bookService, [FromBody]update update)
        {

            return bookService.Update(update);
        }
        [HttpGet("select")]
        public BookRepo GetDetail([FromServices]IBookService bookService, [FromQuery]long id)
        {

            return bookService.GetDetail(id);
        }





        private TodoListDbContext Context;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_context"></param>
        public BookController(TodoListDbContext _context)
        {
            Context = _context;
        }
        /// <summary>
        /// 查询所有的书籍
        /// </summary>
        /// <returns></returns>

        /// <summary>
        /// 查询单本书籍的详情
        /// </summary>
        /// <param name="id">书id</param>
        /// <returns></returns>

        /// <summary>
        /// 新增书籍
        /// </summary>
        /// <param name="model">新增书籍model</param>
        //[HttpPost]
        //[Route("Add")]
        //public bool Add([FromBody]add model)
        //{
        //    Context.BookRepos.Add(new BookRepo()
        //    {
        //        Name = model.Name,
        //        Price = model.Price,
        //        PublishDate = model.PublishDate,
        //        Description = model.Description
        //    });
        //    return Context.SaveChanges() > 0;
        //}
        /// <summary>
        /// 修改书籍
        /// </summary>
        /// <param name="model">修改书籍model</param>
        /// <returns></returns>
        //[HttpPost]
        //[Route("Update")]
        //public bool Update([FromBody] UpdateBook model)
        //{
        //    var entity = Context.BookRepos.Where(o => o.Id == model.Id).FirstOrDefault();
        //    if (entity == null)
        //    {
        //        throw new Exception();
        //    }
        //    entity.Name = model.Name;
        //    entity.Price = model.Price;
        //    entity.PublishDate = model.PublishDate;
        //    entity.Description = model.Description;
        //    return Context.SaveChanges() > 0;
        //}
        /// <summary>
        /// 删除书籍
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Delete")]
        public bool Delete(int id)
        {
            var entity = Context.BookRepos.Where(o => o.Id == id).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception();
            }
            Context.BookRepos.Remove(entity);
            return Context.SaveChanges() > 0;
        }
    }
}
