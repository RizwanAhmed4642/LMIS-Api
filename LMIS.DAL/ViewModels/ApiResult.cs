using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMIS.DAL.ViewModels
{
    public class ApiResult<TEntity> where TEntity : class
    {


        public Exception Exception { get; set; }
        public TEntity resultModel { get; set; }
 

        public bool IsSuccess { get; set; }

        public int StatusCode { get; set; }


    }
}
