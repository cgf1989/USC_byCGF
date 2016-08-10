using BCP.Domain.Service;
using BCP.ViewModel;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Text;

namespace BCP.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        [Dependency]
        public IUserService UserService { get; set; }

        public HttpResponseMessage RegisterUser(UserDTO user)
        {

            if (UserService.RegisterUser(user))
            {
                String str=JsonConvert.SerializeObject(UserService.GetUser(user.UserName));
                //JavaScriptSerializer serializer = new JavaScriptSerializer();
                //string str = serializer.Serialize(user);
                HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
                return result; 
            }
            else
            {
                return new HttpResponseMessage { Content = new StringContent("false", Encoding.GetEncoding("UTF-8"), "application/json") };
            }
        }
    }
}
