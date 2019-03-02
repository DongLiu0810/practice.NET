using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;
using TodoList.Repository;
using TodoList.Repository.Entity;

namespace TodoList.Service.Impl
{
    public class TodoListService : BaseService<Todo>, ITodoListService
    {
        private readonly TodoListDbContext todoListDbContext;
        public TodoListService(TodoListDbContext todoListDbContext)
        {
            this.todoListDbContext = todoListDbContext;
        }

        public TodoListService()
        {
        }

        public IEnumerable<Todo> GetTodoList(long userid)
        {
            var todoList = new List<Todo>();


            #region mock

            //for (int i = 0; i < 10; i++)
            //{
            //    todoList.Add(new Todo { Id = i, Title = string.Format("Todo Tile {0}", i) });
            //}

            #endregion

            #region ado .net

            //// 数据库连接字符串
            //var connStr = "server=localhost;port=3306;Initial Catalog=todo;user id=lm;password=123456;ConnectionReset=false;SslMode = none;";
            //// connection
            //var conn = new MySqlConnection(connStr);
            //conn.Open();
            //// command
            //var cmd = conn.CreateCommand();
            //cmd.CommandText = $"select * from todo where userId = {userId}";
            //var dr = cmd.ExecuteReader();
            //// datareader
            //while(dr.Read())
            //{
            //    var todo = new Todo()
            //    {
            //        Id = dr.GetInt64(0),
            //        Title = dr.GetString("title"),
            //        UserId = dr.GetInt64(2)
            //    };

            //    todoList.Add(todo);
            //}
            //conn.Close();

            #endregion

            #region dapper

            // 数据库连接字符串
            var connStr = "server=192.168.50.208;port=3306;Initial Catalog=training;user id=training;password=123456;ConnectionReset=false;SslMode = none;";
            // connection
            using (var conn = new MySqlConnection(connStr))
            {
                var sqlStr = $"select * from ld_todolist where userid = {userid}";
                todoList = conn.Query<Todo>(sqlStr).ToList();                
            }

            #endregion

            return todoList;
        } // 数据库连接字符串
        public bool Register(string name, string password)
        {
            var connStr = "server=192.168.50.208;port=3306;Initial Catalog=training;user id=training;password=123456;ConnectionReset=false;SslMode = none;";
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                var tran = conn.BeginTransaction();
                try
                {
                    var cmd = conn.CreateCommand();

                    #region 用户注册

                    // 注入风险
                    //cmd.CommandText = $"insert into user(name, password) values ('{name}', '{password}')";
                    // 参数化
                    cmd.CommandText = $"insert into ld_user(username, userpwd) values (@username, @userpwd)";
                    cmd.Parameters.Add(new MySqlParameter("@username", name));
                    cmd.Parameters.Add(new MySqlParameter("@userpwd", password));
                    cmd.Transaction=tran;
                    cmd.ExecuteNonQuery();

                    #endregion

                    #region 获取用户id

                    cmd.CommandText = "select last_insert_id()";
                    var id = long.Parse(cmd.ExecuteScalar().ToString());

                    #endregion

                    #region 插入一条示例todo

                    // 创建todo示例
                    cmd.CommandText = $"insert into ld_todolist(title, userid) values ('示例',{id})";
                    cmd.ExecuteNonQuery();

                    #endregion

                    tran.Commit();

                    return true;
                }
                catch (Exception e)
                {
                    tran.Rollback();

                    return false;
                }
            }
        }
        public bool delate(long id)
        {
            List<Todo> list = new List<Todo>();
            var connStr = "server=192.168.50.208;port=3306;Initial Catalog=training;user id=training;password=123456;ConnectionReset=false;SslMode = none;";
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = $"delete from ld_todolist where t_id = {id}";
                
                cmd.ExecuteNonQuery();
                return true;

            }
        }
        public bool add(long userid, string title)
        {
            var connStr = "server=192.168.50.208;port=3306;Initial Catalog=training;user id=training;password=123456;ConnectionReset=false;SslMode = none;";
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = $"insert into ld_todolist(userid,title) values (@userid,@title)";
                cmd.Parameters.Add(new MySqlParameter("@userid", userid));
                cmd.Parameters.Add(new MySqlParameter("@title", title));
                cmd.ExecuteNonQuery();
                return true;

            }
        }
        public bool check(string name)
        {
            var connStr = "server=192.168.50.208;port=3306;Initial Catalog=training;user id=training;password=123456;ConnectionReset=false;SslMode = none;";
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select userid from ld_user where username = @username";
                cmd.Parameters.Add(new MySqlParameter("@username", name));
                var drs = cmd.ExecuteReader();
                if (drs.Read())
                {
                    return false;
                }
                return true;
            }

        }
        public long Login(string name, string password)
        {
            //var connStr = "server=192.168.50.208;port=3306;Initial Catalog=training;user id=training;password=123456;ConnectionReset=false;SslMode = none;";
            //using (var conn = new MySqlConnection(connStr))
            //    {
            //       conn.Open();
            //     var cmd = conn.CreateCommand();
            //   cmd.CommandText = "select userid from ld_user where username = @username and userpwd = @userpwd";
            // cmd.Parameters.Add(new MySqlParameter("@username", name));
            //  cmd.Parameters.Add(new MySqlParameter("@userpwd", password));
            //  var dr = cmd.ExecuteReader();
            //  if (dr.Read())
            //  {
            //      return dr.GetInt64(0);
            //  }
            //  return 0;
            // }
            ///
            return 1;
        }
    }
}
