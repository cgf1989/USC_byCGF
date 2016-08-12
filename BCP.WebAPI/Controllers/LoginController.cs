using BCP.Common;
using BCP.Domain;
using BCP.Domain.Service;
using BCP.ViewModel;
using BCP.WebAPI.Controllers.Filters;
using BCP.WebAPI.Helpers;
using BCP.WebAPI.SignalR;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace BCP.WebAPI.Controllers
{
    [WebApiFilter]
    public class LoginController : ApiController
    {
        [Dependency]
        public IUserService UserService { get; set; }

        [HttpGet]
        public HttpResponseMessage Login(String userName, String userPwd)
        {
            UserService.InitDataBase();
            if (UserService.Login(userName, userPwd))
            {
                //var str= JsonConvert.SerializeObject(UserService.GetUser(userName));
                //HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
                //return result;
                var userDto = UserService.GetUser(userName);
                MyHub.Login(userDto);
                return JsonHelper.GetResponseMessage(true, "登录成功", typeof(UserDTO), false, userDto);
            }
            else
                throw new Exception("登录失败");
        }

        [HttpGet]
        public HttpResponseMessage Logout(String userId)
        {
            if (UserService.Logout(Convert.ToInt32(userId)))
            {
                MyHub.Logout(Convert.ToInt32(userId));
                return JsonHelper.GetResponseMessage(true, "注销成功", null, false, null);
            }
            else
                throw new Exception("注销失败");
        }
    }
}


