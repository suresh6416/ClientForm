using ClientRequest.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRequest.Services.Contracts
{
    public interface IRequestService 
    {
        List<Request> Get();
        Request GetById(int id);
        void Save(Request data);
        void Delete(int id);
        bool IsNumberExists(string number);
    }
}
