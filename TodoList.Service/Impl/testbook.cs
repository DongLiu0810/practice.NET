using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Service.Dto;

namespace TodoList.Service.Impl
{
    public class testbook
    {
        IBookService bookService;
        public testbook(IBookService bookService) {
            this.bookService = bookService;
        }

        public bool Testadd(adds adds) {
            if (bookService.Add(adds)) {
                if (adds.BookName =="aaa") {
                    return true;
                }
            }
            return false;
        }
        public bool Testupdate(update update)
        {
            if (bookService.Update(update))
            {
                if (update.Id == 123)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
