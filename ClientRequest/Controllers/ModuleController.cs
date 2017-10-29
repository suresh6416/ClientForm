using ClientRequest.Entities.Models;
using ClientRequest.Models.Models;
using ClientRequest.Services.Contracts;
using ClientRequest.Services.Services;
using Microsoft.AspNet.Identity;
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

        [HttpPost]        
        public OperationResult Post(Module module)
        {            
            OperationResult result = new OperationResult();
            try
            {
                module.CreatedBy = module.UpdatedBy = LoggedInUserId;
                lModule.Save(module);
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

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

