using ClientRequest.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRequest.Services.Contracts
{
    public interface IJobNatureService
    {
        List<JobNature> Get();
        JobNature GetById(int id);
        void Save(JobNature job);
        void Delete(int id);
        bool IsNumberExists(string number);
    }
}
