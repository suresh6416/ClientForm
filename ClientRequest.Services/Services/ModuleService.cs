using ClientRequest.Data.Context;
using ClientRequest.Entities.Models;
using ClientRequest.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRequest.Services.Services
{
    public class ModuleService : IModuleService
    {
        APIContext _webcontext = new APIContext();

        public List<Module> Get()
        {           
            return _webcontext.Modules.ToList(); 
        }

        public void Save(Module data)
        {            
            if (data.ID == 0)
            {
                data.IsActive = true;
                data.CreatedBy = data.CreatedBy;
                data.CreatedOn = DateTime.Now;
                _webcontext.Modules.Add(data);
            }
            else
            {
                var module = _webcontext.Modules.Where(m => m.ID == data.ID).FirstOrDefault();
                module.Name = data.Name;
                module.Description = data.Description;
                module.UpdatedBy = data.UpdatedBy;
                module.UpdatedOn = DateTime.Now; 
            }

            _webcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            var module = _webcontext.Modules.Where(m => m.ID == id).FirstOrDefault();
            _webcontext.Modules.Remove(module);
            _webcontext.SaveChanges();
        }
    }
}
