using ClientRequest.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRequest.Services.Contracts
{
    public interface IClientService
    {
        List<Client> Get();
        Client GetById(int id);
        void Save(Client data);
        void Delete(int id);
        bool IsNumberExists(string number);
    }
}
