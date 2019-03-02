
using Microsoft.EntityFrameworkCore;
using Myth.SIS.BurialPoint.Api.DbContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Repository

{
    public class TodoListDbContext : DbContext
    {
        public TodoListDbContext(DbContextOptions options) : base(options) { }
        public DbSet<BookRepo> BookRepos { get; set; }

    }
}

