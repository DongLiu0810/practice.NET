using Myth.SIS.BurialPoint.Api.DbContent;
using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Repository.Entity;
using TodoList.Service.Dto;

namespace TodoList.Service
{
    public interface IBookService : IBaseService<Todo>
    {
        bool remove(long id);
        bool Add(adds add);
        bool Update(update update);
        BookRepo GetDetail(long id);
        
    }
}
