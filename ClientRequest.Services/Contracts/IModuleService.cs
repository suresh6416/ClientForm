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
        Module GetById(int id);
        void Save(Module module);
        void Delete(int id);
        bool IsNumberExists(string number);
    }
}
