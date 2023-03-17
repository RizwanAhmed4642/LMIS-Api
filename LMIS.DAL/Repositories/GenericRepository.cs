using LMIS.DAL.Context;
using LMIS.DAL.Helper;
using LMIS.DAL.Interface;
using LMIS.DAL.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace LMIS.DAL.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal LMISContext context;
        internal DbSet<TEntity> dbSet;






        public GenericRepository(LMISContext context,PagedResponse<TEntity> pagedResponse)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();


        }

        public virtual async Task<PagedResponse<TEntity>> Get(PaginationFilter pagination, IUriService uriService)
        {
            IQueryable<TEntity> query =  dbSet;
        

            PagedResponse<TEntity> _pagedResponse = new PagedResponse<TEntity>();
            if (pagination != null)
            {

                var data =  query
                     .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                     .Take(pagination.PageSize);
           IEnumerable<TEntity> pagedData  = await data.ToListAsync();
                _pagedResponse.Data = pagedData;
                _pagedResponse.TotalRecords = query.Count();

                _pagedResponse = PaginationHelper.CreatePagedReponse<TEntity>(pagedData, pagination, _pagedResponse.TotalRecords, uriService, pagination.route);



                return _pagedResponse;

            }
            return _pagedResponse;




        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual bool Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            if (entityToDelete != null)
            {
                Delete(entityToDelete);
                return true;
            }
            else
                return false;

        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
