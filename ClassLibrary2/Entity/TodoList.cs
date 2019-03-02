using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Repository.Entity
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public long UserId { get; set; }
        public long t_id { get; set; }

    }
}
