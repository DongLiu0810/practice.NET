using Moq;
using System;
using TodoList.Service;
using TodoList.Service.Dto;
using TodoList.Service.Impl;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        private TodoListService todolist;
        private testbook test;

        public UnitTest1()
        {
            todolist = new TodoListService();
        }


        [Fact]
        public void Returnadd()
        {
            var mock = new Mock<IBookService>();
            adds add = new adds();
            add.BookName = "aaa";
            add.Author = "bbb";
            mock.Setup(repo=>repo.Add(add)).Returns(true);
            test = new testbook(mock.Object);
            Assert.True(test.Testadd(add));
        }

        [Fact]
        public void Returnupdate()
        {
            var mock = new Mock<IBookService>();
            update up = new update();
            up.Id =123;
            up.BookName = "aaa";
            mock.Setup(repo => repo.Update(up)).Returns(true);
            test = new testbook(mock.Object);
            Assert.True(test.Testupdate(up));
        }


        [Fact]
        public void Returndelete()
        {
           var results = todolist.delate(321);
           Assert.True(results);
        }
        [Fact]
        public void Returncheck()
        {
            var results = todolist.check("小兰");
            Assert.False(results);
        }
        [Fact]
        public void ReturnRegister()
        {
            var results = todolist.Register("aa","2");
            Assert.True(results);
        }
        [Fact]
        public void ReturnAdd()
        {
            var results = todolist.add(222, "aaaaa");
            Assert.True(results);
        }
    }
}

