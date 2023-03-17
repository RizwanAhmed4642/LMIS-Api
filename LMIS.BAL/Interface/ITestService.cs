
using LMIS.DAL.Entities;
using LMIS.DAL.Interface;
using LMIS.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMIS.BAL.Interface
{
    public interface ITestService
    {
       Task<PagedResponse<Test_tbl>> List(PaginationFilter pagination, IUriService uriService);
       void Insert(Test_tbl model);
       void Update(Test_tbl model);
        Test_tbl GetByID(int Id);
        bool Delete(int Id);
    }
}
