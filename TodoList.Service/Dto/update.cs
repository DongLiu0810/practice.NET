using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Service.Dto
{
    public class update
    {
        public long Id { get; set; }
        /// <summary>
        /// 书名
        /// </summary>
        public string BookName
        {
            get; set;
        }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author
        {
            get; set;
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Description
        {
            get; set;
        }
        /// <summary>
        ///  单价
        /// </summary>
        public decimal Price
        {
            get; set;
        }
        /// <summary>
        ///出版日期
        /// </summary>
        public DateTime PublishDate
        {
            get; set;
        }
    }
}
