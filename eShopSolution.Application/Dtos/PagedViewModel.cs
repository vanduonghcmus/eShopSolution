using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public class PagedViewModel<T>
    {
        // Có thể dùng Page này cho tất cả đối tượng khác nhau
        public List<T> Items { get; set; }// generic Item có tên là T
        public int TotalRecord { get; set; }

    }
}
