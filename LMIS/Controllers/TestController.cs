using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LMIS.BAL.Interface;
using LMIS.DAL.Entities;
using LMIS.DAL.Interface;
using LMIS.DAL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMIS.WEB.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly IUriService uriService;
      
        public TestController(ITestService testService, IUriService uriService) 
        {
            _testService = testService;
            this.uriService = uriService;
        }

        [Route("Manage")]
        [HttpGet]
        public async Task<PagedResponse<Test_tbl>> Manage([FromQuery] PaginationFilter filter )
        {
            filter.route = Request.Path.Value;
       
            var Test_tbls =await _testService.List(filter, uriService);
            return Test_tbls;


        }
        [Route("Insert")]
        [HttpPost]

        public  ActionResult<ApiResult<Test_tbl>> Insert(Test_tbl model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _testService.Insert(model);
                    return new ApiResult<Test_tbl>
                    {
                        resultModel = model,

                        IsSuccess = true,
                        StatusCode = StatusCodes.Status200OK,

                    };
                }
                return new ApiResult<Test_tbl>
                {

                    IsSuccess = false,
                    StatusCode = StatusCodes.Status400BadRequest,
                    Exception = null
                };



            }

            catch (Exception ex)
            {
                return new ApiResult<Test_tbl>
                {
                    IsSuccess = false,
                    StatusCode = StatusCodes.Status400BadRequest,
                    Exception = ex
                };
            }

        }
        [Route("Update")]
        [HttpPost]

        public ActionResult<ApiResult<Test_tbl>> Update(Test_tbl model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _testService.Update(model);
                    return new ApiResult<Test_tbl>
                    {
                        resultModel = model,

                        IsSuccess = true,
                        StatusCode = StatusCodes.Status200OK,

                    };
                }
                return new ApiResult<Test_tbl>
                {

                    IsSuccess = false,
                    StatusCode = StatusCodes.Status400BadRequest,
                    Exception = null
                };



            }

            catch (Exception ex)
            {
                return new ApiResult<Test_tbl>
                {
                    IsSuccess = false,
                    StatusCode = StatusCodes.Status400BadRequest,
                    Exception = ex
                };
            }

        }
        [Route("GetByID")]
        [HttpGet]
        public ActionResult<ApiResult<Test_tbl>> GetByID(int Id)
        {
            try
            {

                Test_tbl model= _testService.GetByID(Id);
                    return new ApiResult<Test_tbl>
                    {
                        resultModel = model,
                        IsSuccess = true,
                        StatusCode = StatusCodes.Status200OK,

                    };
            
                return new ApiResult<Test_tbl>
                {

                    IsSuccess = false,
                    StatusCode = StatusCodes.Status400BadRequest,
                    Exception = null
                };



            }

            catch (Exception ex)
            {
                return new ApiResult<Test_tbl>
                {
                    IsSuccess = false,
                    StatusCode = StatusCodes.Status400BadRequest,
                    Exception = ex
                };
            }

        }
        [Route("Delete")]
        [HttpGet]
        public ActionResult<ApiResult<Test_tbl>> Delete(int Id)
        {
            try
            {

              bool res= _testService.Delete(Id);
                if(res==true)
                { 
                return new ApiResult<Test_tbl>
                {
                 
                    IsSuccess = true,
                    StatusCode = StatusCodes.Status200OK,

                };
                }
                else
                {
                    return new ApiResult<Test_tbl>
                    {

                        IsSuccess = false,
                        StatusCode = StatusCodes.Status404NotFound,

                    };
                }


             


            }

            catch (Exception ex)
            {
                return new ApiResult<Test_tbl>
                {
                    IsSuccess = false,
                    StatusCode = StatusCodes.Status400BadRequest,
                    Exception = ex
                };
            }

        }

    }
}