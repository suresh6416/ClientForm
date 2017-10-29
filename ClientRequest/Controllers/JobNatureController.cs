using ClientRequest.Entities.Models;
using ClientRequest.Models.Models;
using ClientRequest.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClientRequest.Controllers
{
    [RoutePrefix("api/JobNature")]
    //[Authorize]
    public class JobNatureController : BaseController
    {
        IJobNatureService lJobNature;

        public JobNatureController(IJobNatureService _lJobNature)
        {
            lJobNature = _lJobNature;
        }

        /// <summary>
        /// Get Job Natures
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public OperationResult Get()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lJobNature.Get();
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Get Job Nature By Id
        /// </summary>
        /// <param name="id">Job Nature Id</param>
        /// <returns></returns>
        [HttpGet]
        public OperationResult GetById(int id)
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lJobNature.GetById(id);
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Add Job Nature
        /// </summary>
        /// <param name="jobNature">model</param>
        /// <returns></returns>
        [HttpPost]
        public OperationResult Post(JobNature jobNature)
        {
            OperationResult result = new OperationResult();
            try
            {
                jobNature.CreatedBy = jobNature.UpdatedBy = LoggedInUserName;
                lJobNature.Save(jobNature);
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Delete Job Nature
        /// </summary>
        /// <param name="id">Job Nature Id</param>
        /// <returns></returns>
        [HttpDelete]
        public OperationResult Delete(int id)
        {
            OperationResult result = new OperationResult();

            try
            {
                lJobNature.Delete(id);
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Check whether job nature existed or not
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpGet]
        public OperationResult IsNumberExists(string number)
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lJobNature.IsNumberExists(number);
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
