using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMIS.DAL.ViewModels
{
    public class PagedResponse<T> 
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Uri FirstPage { get; set; }
        public Uri LastPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public Uri NextPage { get; set; }
        public Uri PreviousPage { get; set; }
        public IEnumerable<T> Data { get; set; }
        //public PagedResponse(IEnumerable<T> data, int pageNumber, int pageSize)
        //{
        //    this.PageNumber = pageNumber;
        //    this.PageSize = pageSize;
        //    this.Data = data;
    
        //}
    }
}
