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
    [RoutePrefix("api/Client")]
    //[Authorize]
    public class ClientController : BaseController
    {
        IClientService lClient;
        public ClientController(IClientService _lClient)
        {
            lClient = _lClient;
        }

        /// <summary>
        /// Get Clients
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public OperationResult Get()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lClient.Get();
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Get Client By Id
        /// </summary>
        /// <param name="id">Client Id</param>
        /// <returns></returns>
        [HttpGet]
        public OperationResult GetById(int id)
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lClient.GetById(id);
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Add Client
        /// </summary>
        /// <param name="jobNature">model</param>
        /// <returns></returns>
        [HttpPost]
        public OperationResult Post(Client client)
        {
            OperationResult result = new OperationResult();
            try
            {
                lClient.Save(client, LoggedInUserName);
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Delete Client
        /// </summary>
        /// <param name="id">Client Id</param>
        /// <returns></returns>
        [HttpDelete]
        public OperationResult Delete(int id)
        {
            OperationResult result = new OperationResult();

            try
            {
                lClient.Delete(id);
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Check whether client existed or not
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpPost]
        public OperationResult IsNumberExists(string number)
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lClient.IsNumberExists(number);
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
