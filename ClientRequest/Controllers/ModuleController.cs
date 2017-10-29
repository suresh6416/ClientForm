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
            var classResults = lModule.Get();
            result.Data = classResults;
            result.Status = OperationStatus.SUCCESS;
            return result;
        }


        [HttpPost]
        //[Authorize]
        public OperationResult Post(Module module)
        {            
            OperationResult result = new OperationResult();
            module.CreatedBy = module.UpdatedBy = LoggedInUserId;
            lModule.Save(module);
            result.Status = OperationStatus.SUCCESS;
            return result;
        }

        [HttpDelete]
        //[Authorize]
        public OperationResult Delete(int id)
        {
            OperationResult result = new OperationResult();            
            lModule.Delete(id);
            result.Status = OperationStatus.SUCCESS;
            return result;
        }
    }
}

