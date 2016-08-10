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
using BCP.WebAPI.Helpers;

namespace BCP.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        [Dependency]
        public IUserService UserService { get; set; }

        public HttpResponseMessage RegisterUser(UserDTO user)
        {
            try
            {
                if (UserService.RegisterUser(user))
                {
                    //String str=JsonConvert.SerializeObject(UserService.GetUser(user.UserName));
                    //JavaScriptSerializer serializer = new JavaScriptSerializer();
                    //string str = serializer.Serialize(user);
                    //HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
                    //return result; 
                    return JsonHelper.GetResponseMessage(true, "登录成功", typeof(UserDTO), false, UserService.GetUser(user.UserName));
                }
            }
            catch (Exception ex)
            {
                return JsonHelper.GetResponseMessage(false, "登录失败"+ex.Message, null, false, null);
            }
            return JsonHelper.GetResponseMessage(false, "登录失败", null, false, null);
        }
    }
}
