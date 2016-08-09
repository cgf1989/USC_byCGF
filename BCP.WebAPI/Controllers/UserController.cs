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

namespace BCP.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        [Dependency]
        public IUserService UserService { get; set; }

        public String RegisterUser(UserDTO user)
        {

            if (UserService.RegisterUser(user))
            {
                return JsonConvert.SerializeObject(UserService.GetUser(user.UserName));
            }
            else
            {
                return "false";
            }
        }
    }
}
