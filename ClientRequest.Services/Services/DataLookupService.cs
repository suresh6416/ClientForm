using ClientRequest.Data.Context;
using ClientRequest.Entities.ComplexModels;
using ClientRequest.Entities.Models;
using ClientRequest.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRequest.Services.Services
{
    public class DataLookupService : IDataLookupService
    {
        public List<DataLookupModel> ModuleLookup()
        {
            var result = (from d in new APIContext().Modules
                          where d.IsActive == true
                          select new DataLookupModel { ID = d.ID, Number = d.Number, Name = d.Name }).ToList();

            return result;
        }

        public List<DataLookupModel> JobNatureLookup()
        {
            var result = (from d in new APIContext().JobNatures
                          where d.IsActive == true
                          select new DataLookupModel { ID = d.ID, Number = d.Number, Name = d.Name }).ToList();

            return result;
        }

        public List<DataLookupModel> ClientLookup()
        {
            var result = (from d in new APIContext().Clients
                          where d.IsActive == true
                          select new DataLookupModel { ID = d.ID, Number = d.Number, Name = d.Name }).ToList();

            return result;
        }
    }
}
