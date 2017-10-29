using ClientRequest.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRequest.Services.Contracts
{
    public interface IModuleService
    {
        List<Module> Get();
        void Save(Module module);
        void Delete(int id);
    }
}
