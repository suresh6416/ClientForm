using ClientRequest.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRequest.Services.Contracts
{
    public interface IProductDetails
    {
        bool SaveProducts(Product pob);
        List<Product> showDetails();
        bool DeleteDetails(int id);
    }
}
