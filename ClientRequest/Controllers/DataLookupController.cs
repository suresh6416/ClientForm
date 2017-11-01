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
    [RoutePrefix("api/DataLookup")]
    //[Authorize]
    public class DataLookupController : BaseController
    {
        IDataLookupService lDataLookup;
        public DataLookupController(IDataLookupService _lDataLookup)
        {
            lDataLookup = _lDataLookup;
        }

        /// <summary>
        /// Get Module Lookup
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ModuleLookup")]
        public OperationResult ModuleLookup()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lDataLookup.ModuleLookup();
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Get Job Nature Lookup
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("JobNatureLookup")]
        public OperationResult JobNatureLookup()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lDataLookup.JobNatureLookup();
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Get Client Lookup
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ClientLookup")]
        public OperationResult ClientLookup()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lDataLookup.ClientLookup();
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
