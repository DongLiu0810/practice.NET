using Myth.SIS.BurialPoint.Api.DbContent;
using System;
using System.Linq;
using TodoList.Repository;
using TodoList.Repository.Entity;
using TodoList.Service.Dto;

namespace TodoList.Service.Impl
{
    public class BookService : BaseService<Todo>, IBookService
    {


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_context"></param>
         TodoListDbContext Context;
        public BookService(TodoListDbContext Context)
        {
           this.Context = Context;
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool remove (long id)
        {
            var entity = Context.BookRepos.Where(o => o.Id == id).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception();
            }
           Context.BookRepos.Remove(entity);
            return Context.SaveChanges() > 0;
        }
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Add(adds add)
        {
           Context.BookRepos.Add(new BookRepo()
            {
                Name = add.BookName, 
                Price = add.Price,
                PublishDate = add.PublishDate,
                Description = add.Description
            });
            return Context.SaveChanges() > 0;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        public bool Update(update update)
        {
            var entity = Context.BookRepos.Where(o => o.Id == update.Id).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception();
            }
            entity.Name = update.BookName;
            entity.Price = update.Price;
            entity.PublishDate = update.PublishDate;
            entity.Description = update.Description;
            return Context.SaveChanges() > 0;
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BookRepo GetDetail (long id)
        {
            var result = Context.BookRepos.Where(o => o.Id == id).Select(o => new BookRepo()
            {
                Id = o.Id,
                Name = o.Name,
                Description = o.Description,
                PublishDate = o.PublishDate,
                Price = o.Price
            }).FirstOrDefault();
            return result;
        }
    }
}
