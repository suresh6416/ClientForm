using ClientRequest.Entities.Models;
using ClientRequest.Services.Contracts;
using ClientRequest.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ClientRequest.Controllers
{
    public class ModuleController : BaseController
    {        
        IProductDetails iprod;

        
        public ModuleController(IProductDetails _iprod)
        {
            iprod = _iprod;
        }

        [HttpPost]
        [Route("addProduct")]
        //[Authorize]
        public async Task<HttpResponseMessage> saveProductDetails(Product pod)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            bool res = false;
            string errordetails = "";
            var errors = new List<string>();
            if (ModelState.IsValid)
            {
                try
                {
                    res = iprod.SaveProducts(pod);

                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
            else
            {


                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        string p = error.ErrorMessage;
                        errordetails = errordetails + error.ErrorMessage;

                    }
                }

                dict.Add("error", errordetails);
                return Request.CreateResponse(HttpStatusCode.BadRequest, dict);

            }

            if (res == true)
            {
                var showmessage = "Product Saved Successfully.";

                dict.Add("Message", showmessage);
                return Request.CreateResponse(HttpStatusCode.OK, dict);

            }
            else
            {
                var showmessage = "Product Not Saved Please try again.";

                dict.Add("Message", showmessage);
                return Request.CreateResponse(HttpStatusCode.BadRequest, dict);

            }
        }

        [Route("showproduct")]
        [HttpGet]

        public async Task<HttpResponseMessage> getAllProduct()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            var details = iprod.showDetails();
            if (details != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, details);

            }
            else
            {
                var showmessage = "No product found.";

                dict.Add("Message", showmessage);
                return Request.CreateResponse(HttpStatusCode.OK, details);

            }
        }


    }
}

