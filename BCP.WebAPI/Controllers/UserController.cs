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
            UserDTO user = new UserDTO() { 
                ActualName = actualName, UserName = userName, Password = userPwd, EventTime = 1,Domain="",DomainId="",
                LimiteTime = DateTime.Now, Note = "", Status = "false" };
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

        /// <summary>
        /// 用户新增一个分组
        /// </summary>
        /// <param name="userId">分组创建者Id</param>
        /// <param name="groupName">分组名称</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage AddCustomerGroup(String userId,String groupName)
        {
            if (UserService.AddCustomerGroup(new CustomerGoupDTO() { CreatID = Convert.ToInt32(userId), GroupName = groupName }))
            {
                return JsonHelper.GetResponseMessage(true, "创建分组成功", null, false, null);
            }
            else
                throw new Exception("创建分组失败");
        }

        /// <summary>
        /// 修改分组名称
        /// </summary>
        /// <param name="groupId">分组Id</param>
        /// <param name="groupName">分组名称</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage UpdateCustomerGroupName(String groupId,String groupName)
        {
            if (UserService.UpdateCustomerGroupName(Convert.ToInt32(groupId), groupName))
            {
                return JsonHelper.GetResponseMessage(true, "修改分组名称成功", null, false, null);
            }
            else
                throw new Exception("修改分组名称失败");
        }

        /// <summary>
        /// 删除空的分组（当分组下有用户执行失败)
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DeleteCustomerGroup(String groupId)
        {
            if (UserService.DeleteCustomerGroup(Convert.ToInt32(groupId)))
            {
                return JsonHelper.GetResponseMessage(true, "删除分组成功", null, false, null);
            }
            else
                throw new Exception("删除分组失败");
        }

        /// <summary>
        /// 获取所有分组（包括分组成员）
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllCustomerGroupWithUser(String userId)
        {
            return JsonHelper.GetResponseMessage(true, "获取用户所有分组数据", typeof(CustomerGoupDTO), true, UserService.GetCustomerGroup(Convert.ToInt32(userId), true));
        }

        /// <summary>
        /// 获取所有分组（不包括分组成员）
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllCustomerGroupWithoutUser(String userId)
        {
            return JsonHelper.GetResponseMessage(true, "获取用户所有分组数据", typeof(CustomerGoupDTO), true, UserService.GetCustomerGroup(Convert.ToInt32(userId), false));
        }

        /// <summary>
        /// 获取一个分组的所有成员
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetUserFromCustomerGroup(String groupId)
        {
            return JsonHelper.GetResponseMessage(true, "获取用户所有分组数据", typeof(UserDTO), true, UserService.GetUserByGroupId(Convert.ToInt32(groupId)));
        }

        /// <summary>
        /// 添加一个用户到分组
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage AddUserToCustomerGroup(String userId,String groupId)
        {
            if (UserService.AddUserToCustomerGroup(Convert.ToInt32(userId), Convert.ToInt32(groupId)))
            {
                return JsonHelper.GetResponseMessage(true, "添加用户到分组成功", null, false, null);
            }
            else
                throw new Exception("添加用户到分组失败");
        }

        /// <summary>
        /// 从分组移除一个成员
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage RemoveUserFromCustomerGroup(String userId,String groupId)
        {
            if (UserService.RemoveUserFromCustomerGroup(Convert.ToInt32(userId), Convert.ToInt32(groupId)))
            {
                return JsonHelper.GetResponseMessage(true, "从分组删除用户成功", null, false, null);
            }
            else
                throw new Exception("从分组删除用户失败");
        }
    }
}
