using ClientRequest.Entities.ComplexModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRequest.Services.Contracts
{
    public interface IDataLookupService
    {
        List<DataLookupModel> ModuleLookup();
        List<DataLookupModel> JobNatureLookup();
        List<DataLookupModel> ClientLookup();
    }
}
