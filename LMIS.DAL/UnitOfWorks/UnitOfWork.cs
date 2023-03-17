

using LMIS.DAL.Context;
using LMIS.DAL.Entities;
using LMIS.DAL.Repositories;
using LMIS.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMIS.DAL.UnitOfWorks
{
    public class UnitOfWork : IDisposable
    {
        private LMISContext context = new LMISContext();
        public PagedResponse<Test_tbl> TestPagedResponse;

        private GenericRepository<Test_tbl> testRepository;
     //   private readonly IUriService uriService;


        public GenericRepository<Test_tbl> TestRepository
        {
            get
            {

                if (this.testRepository == null)
                {
                    this.testRepository = new GenericRepository<Test_tbl>(context, TestPagedResponse);
                }
                return testRepository;
            }
        }

       

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
