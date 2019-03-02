using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Service.Impl
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
    }
}
