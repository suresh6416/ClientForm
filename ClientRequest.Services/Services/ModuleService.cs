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
            return _webcontext.Modules.Where(m =>  m.IsActive == true).ToList();
        }

        public Module GetById(int id)
        {
            return _webcontext.Modules.Where(m => m.ID == id && m.IsActive == true).FirstOrDefault();
        }

        public void Save(Module data, string loggedInUserName)
        {
            if (data.ID == 0 && !IsNumberExists(data.Number))
            {
                data.IsActive = true;
                data.CreatedBy = loggedInUserName;
                data.CreatedOn = DateTime.Now;
                _webcontext.Modules.Add(data);
            }
            else
            {
                var module = _webcontext.Modules.Where(m => m.ID == data.ID).FirstOrDefault();
                module.Name = data.Name;
                module.Description = data.Description;
                module.UpdatedBy = loggedInUserName;
                module.UpdatedOn = DateTime.Now;
            }

            _webcontext.SaveChanges();

        }

        public void Delete(int id)
        {
            var module = _webcontext.Modules.Where(m => m.ID == id).FirstOrDefault();
            module.IsActive = false;
            _webcontext.SaveChanges();
        }

        public bool IsNumberExists(string number)
        {
            var module = _webcontext.Modules.Where(m => m.Number == number && m.IsActive == true).FirstOrDefault();
            return module != null ? true : false;
        }
    }
}
