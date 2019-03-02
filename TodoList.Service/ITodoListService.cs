using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Repository.Entity;

namespace TodoList.Service
{
    public interface ITodoListService : IBaseService<Todo>
    {
        IEnumerable<Todo> GetTodoList(long userId);
        bool Register(string name, string password);
        bool check(string name);
        bool add(long userid,string title);
        long Login(string name, string password);
        bool delate(long id);
    }
}
