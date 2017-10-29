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
    public class ProductDetails : IProductDetails
    {
        APIContext _webcontext = new APIContext();

        public List<Product> showDetails()
        {
            List<Product> li = new List<Product>();
            var details = _webcontext.Products.ToList();
            if (details != null)
            {
                Parallel.ForEach(details, x =>
                {
                    Product obj = new Product();
                    obj.slNO = x.slNO;
                    obj.ProductName = x.ProductName;
                    obj.Price = Convert.ToInt32(x.Price);
                    li.Add(obj);

                });
                return li;
            }
            else
            {
                return li;
            }

        }

        public bool SaveProducts(Product pobj)
        {
            _webcontext.Products.Add(pobj);
            int m = _webcontext.SaveChanges();
            if (m == 1)
            {
                return true;
            }
            else
            {
                return false;
            }



        }

        public bool DeleteDetails(int id)
        {
            var Info = _webcontext.Products.Where(m => m.productId == id).FirstOrDefault();
            _webcontext.Products.Remove(Info);
            if (_webcontext.SaveChanges() == 0)
                return true;
            return false;
        }
    }
}
