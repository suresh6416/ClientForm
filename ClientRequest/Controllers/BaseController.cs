using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ClientRequest.Controllers
{
    public class BaseController : ApiController
    {
        /// <summary>
        /// Gets the logged in user id 
        /// </summary>
        internal string LoggedInUserId
        {
            get
            {
                if (HttpContext.Current.Request.IsAuthenticated)
                {
                    return User.Identity.GetUserId();
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the logged in user name 
        /// </summary>
        internal string LoggedInUserName
        {
            get
            {
                if (HttpContext.Current.Request.IsAuthenticated)
                {
                    return User.Identity.GetUserName();
                }

                return null;
            }
        }
    }
}
