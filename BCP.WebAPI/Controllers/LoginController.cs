using BCP.Common;
using BCP.Domain;
using BCP.Domain.Service;
using BCP.ViewModel;
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
    public class LoginController : ApiController
    {
        [Dependency]
        public IUserService UserService { get; set; }

        [HttpGet]
        public HttpResponseMessage Login(String userName, String userPwd)
        {
            try
            {
                UserService.InitDataBase();
                if (UserService.Login(userName, userPwd))
                {
                    //var str= JsonConvert.SerializeObject(UserService.GetUser(userName));
                    //HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
                    //return result;
                    var userDto=UserService.GetUser(userName);
                    MyHub.Login(userDto);
                    return JsonHelper.GetResponseMessage(true, "登录成功", typeof(UserDTO), false, userDto);

                }
            }
            catch (Exception ex)
            {
                return JsonHelper.GetResponseMessage(false, "登录失败"+ex.Message, null, false, null);
            }
            return JsonHelper.GetResponseMessage(false, "登录失败", null, false, null);
        }

        [HttpGet]
        public HttpResponseMessage Logout(String userId)
        {
            try
            {
                if (UserService.Logout(Convert.ToInt32(userId)))
                {
                    MyHub.Logout(Convert.ToInt32(userId));
                    return JsonHelper.GetResponseMessage(true, "注销成功", null, false, null);
                }
            }
            catch (Exception ex)
            { }
            return JsonHelper.GetResponseMessage(false, "注销失败", null, false, null);
        }
    }
}


