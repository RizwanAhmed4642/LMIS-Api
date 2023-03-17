using System;
using System.Collections.Generic;
using System.Text;

namespace LMIS.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITest_tblRepository Test_tbls { get; }
        IProjectRepository Projects { get; }
        int Complete();
    }
}
