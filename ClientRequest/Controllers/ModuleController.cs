using ClientRequest.Entities.Models;
using ClientRequest.Models.Models;
using ClientRequest.Services.Contracts;
using ClientRequest.Services.Services;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ClientRequest.Controllers
{
    [RoutePrefix("api/Module")]    
    //[Authorize]
    public class ModuleController : BaseController
    {        
        IModuleService lModule;
        
        public ModuleController(IModuleService _lModule)
        {
            lModule = _lModule;
        }

        /// <summary>
        /// Get Mudules
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        public OperationResult Get()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lModule.Get();
                result.Status = OperationStatus.SUCCESS;                
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Get Module By Id
        /// </summary>
        /// <param name="id">Module Id</param>
        /// <returns></returns>
        [HttpGet]
        public OperationResult GetById(int id)
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lModule.GetById(id);
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Add Module
        /// </summary>
        /// <param name="module">model</param>
        /// <returns></returns>
        [HttpPost]        
        public OperationResult Post(Module module)
        {            
            OperationResult result = new OperationResult();
            try
            {
                module.CreatedBy = module.UpdatedBy = LoggedInUserName;
                lModule.Save(module);
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Delete Module
        /// </summary>
        /// <param name="id">Module Id</param>
        /// <returns></returns>
        [HttpDelete]
        public OperationResult Delete(int id)
        {
            OperationResult result = new OperationResult();           
            
            try
            {
                lModule.Delete(id);
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Check whether module existed or not
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpGet]
        public OperationResult IsNumberExists(string number)
        {
            OperationResult result = new OperationResult();           
            try
            {
                result.Data = lModule.IsNumberExists(number);
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

