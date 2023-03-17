using AutoMapper;
using LMIS.BAL.Interface;
using LMIS.DAL.ViewModels;
using LMIS.DAL.Context;
using LMIS.DAL.Entities;
using LMIS.DAL.IdentityModel;
using LMIS.DAL.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMIS.DAL.UnitOfWorks;

namespace LMIS.Business.Service
{
    public class TestService : ITestService
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly LMISContext dbContext;
        private readonly IMapper mapper;
        private UnitOfWork unitOfWork = new UnitOfWork();


        public TestService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, LMISContext dbContext, IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<PagedResponse<Test_tbl>> List(PaginationFilter pagination, IUriService uriService)
        {
        var list = unitOfWork.TestRepository.Get(pagination, uriService);
            return await list;
         }
        public void Insert(Test_tbl model)
        {
            unitOfWork.TestRepository.Insert(model);
            unitOfWork.Save();
     

        }
        public void Update(Test_tbl model)
        {
            unitOfWork.TestRepository.Update(model);
            unitOfWork.Save();
     

        } 
        public Test_tbl GetByID(int Id)
        {
           return unitOfWork.TestRepository.GetByID(Id);
     
     

        }
        public  bool Delete(int Id)
        {
            bool resp = unitOfWork.TestRepository.Delete(Id);
            if (resp == true)
            {
                unitOfWork.Save();
                return true;
            }
            else
                return false;
            


        }

    }
}
