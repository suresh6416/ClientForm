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
    [RoutePrefix("api/Request")]
    //[Authorize]
    public class RequestController : BaseController
    {
        IRequestService lRequest;
        public RequestController(IRequestService _lRequest)
        {
            lRequest = _lRequest;
        }

        /// <summary>
        /// Get Requests
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public OperationResult Get()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lRequest.Get();
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Get Request By Id
        /// </summary>
        /// <param name="id">Request Id</param>
        /// <returns></returns>
        [HttpGet]
        public OperationResult GetById(int id)
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lRequest.GetById(id);
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Add Request
        /// </summary>
        /// <param name="request">model</param>
        /// <returns></returns>
        [HttpPost]
        public OperationResult Post(Request request)
        {
            OperationResult result = new OperationResult();
            try
            {
                request.CreatedBy = request.UpdatedBy = LoggedInUserName;
                lRequest.Save(request);
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Delete Request
        /// </summary>
        /// <param name="id">Request Id</param>
        /// <returns></returns>
        [HttpDelete]
        public OperationResult Delete(int id)
        {
            OperationResult result = new OperationResult();

            try
            {
                lRequest.Delete(id);
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Check whether request existed or not
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpGet]
        public OperationResult IsNumberExists(string number)
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lRequest.IsNumberExists(number);
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
