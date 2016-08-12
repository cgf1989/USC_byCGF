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
using BCP.WebAPI.Controllers.Filters;

namespace BCP.WebAPI.Controllers
{
    [WebApiFilter]
    public class UserController : ApiController
    {
        [Dependency]
        public IUserService UserService { get; set; }

        [HttpGet]
        public HttpResponseMessage RegisterUser(String userName,String userPwd,String actualName)
        {
            UserDTO user = new UserDTO() { ActualName = actualName, UserName = userName, Password = userPwd, EventTime = 1, LimiteTime = DateTime.Now, Note = "", Status = "false" };
            if (UserService.RegisterUser(user))
            {
                //String str=JsonConvert.SerializeObject(UserService.GetUser(user.UserName));
                //JavaScriptSerializer serializer = new JavaScriptSerializer();
                //string str = serializer.Serialize(user);
                //HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
                //return result; 
                return JsonHelper.GetResponseMessage(true, "注册成功", typeof(UserDTO), false, UserService.GetUser(user.UserName));
            }
            else
                throw new Exception("注册失败");
        }

        [HttpGet]
        public HttpResponseMessage UpdateUser(string id, String userName, String userPwd)
        {
            if (UserService.UpdateUserPwd(Convert.ToInt32(id), userPwd))
            {
                return JsonHelper.GetResponseMessage(true, "修改成功", typeof(UserDTO), false, UserService.GetUser(Convert.ToInt32(id)));
            }
            else
                throw new Exception("修改失败");
        }

        [HttpGet]
        public HttpResponseMessage DeleteUser(String id)
        {
            if (UserService.DeleteUser(Convert.ToInt32(id)))
            {
                return JsonHelper.GetResponseMessage(true, "删除成功", typeof(bool), false, true);
            }
            else
                throw new Exception("删除失败");
        }

        [HttpGet]
        public HttpResponseMessage GetAllUser()
        {
            return JsonHelper.GetResponseMessage(true, "获取成功", typeof(UserDTO), true, UserService.GetUser());
        }
    }
}
