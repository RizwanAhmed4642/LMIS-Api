using LMIS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMIS.DAL.Interfaces
{
    public interface ITest_tblRepository : IGenericRepository<Test_tbl>
    {
        IEnumerable<Test_tbl> GetPopularTest_tbls(int count);
    }
}
