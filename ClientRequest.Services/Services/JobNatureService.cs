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
    public class JobNatureService : IJobNatureService
    {
        APIContext _webcontext = new APIContext();

        public List<JobNature> Get()
        {
            return _webcontext.JobNatures.ToList();
        }

        public JobNature GetById(int id)
        {
            return _webcontext.JobNatures.Where(m => m.ID == id).FirstOrDefault();
        }

        public void Save(JobNature data)
        {
            if (data.ID == 0)
            {
                data.IsActive = true;
                data.CreatedBy = data.CreatedBy;
                data.CreatedOn = DateTime.Now;
                _webcontext.JobNatures.Add(data);
            }
            else
            {
                var job = _webcontext.JobNatures.Where(m => m.ID == data.ID).FirstOrDefault();
                job.Name = data.Name;
                job.Description = data.Description;
                job.UpdatedBy = data.UpdatedBy;
                job.UpdatedOn = DateTime.Now;
            }

            _webcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            var job = _webcontext.JobNatures.Where(m => m.ID == id).FirstOrDefault();
            _webcontext.JobNatures.Remove(job);
            _webcontext.SaveChanges();
        }

        public bool IsNumberExists(string number)
        {
            var job = _webcontext.JobNatures.Where(m => m.Number == number).FirstOrDefault();
            return job != null ? true : false;
        }
    }
}
