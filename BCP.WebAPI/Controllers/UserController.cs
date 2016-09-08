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
using BCP.WebAPI.SignalR;
using System.Threading.Tasks;
using System.Web;
using System.Diagnostics;
using System.IO;
using BCP.Common.Helper;
using System.Web.Hosting;
using System.Net.Http.Headers;

namespace BCP.WebAPI.Controllers
{
    [WebApiFilter]
    public class UserController : ApiController
    {
        private static readonly object _lockObject = new object();

        [Dependency]
        public IUserService UserService { get; set; }

        [HttpGet]
        public HttpResponseMessage RegisterUser(String userName,String userPwd,String actualName)
        {
            UserDTO user = new UserDTO() { 
                ActualName = actualName, UserName = userName, Password = userPwd, Domain="",DomainId="",
                CreateTime=DateTime.Now,
                LimitTime = DateTime.Now, Notes = "", State = 0 };
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
                var user=UserService.GetUser(Convert.ToInt32(id));
                MyHub.UpdateOnLineUser(user);
                return JsonHelper.GetResponseMessage(true, "修改成功", typeof(UserDTO), false, user);
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
        /// 根据用户名获取Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetUserById(String id)
        {
            return JsonHelper.GetResponseMessage(true, "获取成功", typeof(UserDTO), false, UserService.GetUser(Convert.ToInt32(id)));
        }


        #region customerGroup

        /// <summary>
        /// 用户新增一个分组
        /// </summary>
        /// <param name="userId">分组创建者Id</param>
        /// <param name="groupName">分组名称</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage AddCustomerGroup(String userId,String groupName)
        {
            if (UserService.AddCustomGroup(new CustomGroupDTO() { CreateUserId = Convert.ToInt32(userId), GroupName = groupName,CreatTime=DateTime.Now }))
            {
                return JsonHelper.GetResponseMessage(true, "创建分组成功", typeof(CustomGroupDTO), false, 
                    UserService.GetCustomGroup(Convert.ToInt32(userId),true).Where(it=>it.GroupName==groupName).FirstOrDefault());
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
            if (UserService.UpdateCustomGroupName(Convert.ToInt32(groupId), groupName))
            {
                return JsonHelper.GetResponseMessage(true, "修改分组名称成功", typeof(CustomGroupDTO), false, UserService.GetCustomGroupById(Convert.ToInt32(groupId)));
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
            if (UserService.DeleteCustomGroup(Convert.ToInt32(groupId)))
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
            return JsonHelper.GetResponseMessage(true, "获取用户所有分组数据", typeof(CustomGroupDTO), true, UserService.GetCustomGroup(Convert.ToInt32(userId), true));
        }

        /// <summary>
        /// 获取所有分组（不包括分组成员）
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllCustomerGroupWithoutUser(String userId)
        {
            return JsonHelper.GetResponseMessage(true, "获取用户所有分组数据", typeof(CustomGroupDTO), true, UserService.GetCustomGroup(Convert.ToInt32(userId), false));
        }

        /// <summary>
        /// 获取一个分组的所有成员
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetUserFromCustomerGroup(String groupId)
        {
            return JsonHelper.GetResponseMessage(true, "获取用户所有分组数据", typeof(UserDTO), true, UserService.GetUserByCustomGroupId(Convert.ToInt32(groupId)));
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
            if (UserService.AddUserToCustomGroup(Convert.ToInt32(userId), Convert.ToInt32(groupId)))
            {
                return JsonHelper.GetResponseMessage(true, "添加用户到分组成功", typeof(CustomGroupDTO), false,
                    UserService.GetCustomGroupById(Convert.ToInt32(groupId)));
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
            if (UserService.RemoveUserFromCustomGroup(Convert.ToInt32(userId), Convert.ToInt32(groupId)))
            {
                return JsonHelper.GetResponseMessage(true, "从分组删除用户成功", null, false, null);
            }
            else
                throw new Exception("从分组删除用户失败");
        }

        #endregion

        #region group

        /// <summary>
        /// 创建一个群组
        /// </summary>
        /// <param name="userId">创建者Id</param>
        /// <param name="groupNumber">群号</param>
        /// <param name="groupName">群名</param>
        /// <param name="groupNotes">备注</param>
        /// <param name="groupType">群类型</param>
        /// <param name="groupValidate">？</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage RegisterGroup(String userId,String groupNumber,String groupName,String groupNotes,String groupType,int groupValidate)
        {
            if (UserService.RegisterGroup(new GroupDTO()
            {
                CreatTime = DateTime.Now,
                GroupNo = groupNumber,
                Name = groupName,
                Notes = groupNotes,
                State = 0,
                Category = groupType,
                UserId = Convert.ToInt32(userId),
                CreateUserId = Convert.ToInt32(userId),
                ValidattionPattern = groupValidate
            }))
            {
                MyHub.UpdateOnLineUser(UserService.GetUser(Convert.ToInt32(userId)));
                return JsonHelper.GetResponseMessage(true, "创建群组成功", typeof(GroupDTO), false, 
                    UserService.GetAllGroupByUserId(Convert.ToInt32(userId),true).Where(it=>it.UserId.ToString().Equals(userId)).ToList());
            }
            throw new Exception("创建群组失败");
        }

        /// <summary>
        /// 修改群组信息
        /// </summary>
        /// <param name="groupNumber">群号</param>
        /// <param name="groupName">群名</param>
        /// <param name="groupNotes">备注</param>
        /// <param name="groupType">群类型</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage UpdateGroupInfo(String groupId,String groupNumber,String groupName,String groupNotes,String groupType,String userId)
        {
            if (UserService.UpdateGroup(Convert.ToInt32(groupId), groupNumber, groupName, groupNotes, groupType,Convert.ToInt32(userId)))
            {
                return JsonHelper.GetResponseMessage(true, "修改群组成功", typeof(GroupDTO), false, UserService.GetGroupById(Convert.ToInt32(groupId)));
            }
            throw new Exception("修改群组失败");
        }

        /// <summary>
        /// 删除群组(群组成员为空)
        /// </summary>
        /// <param name="groupId">群组主键</param>
        /// <param name="userId">登录用户主键</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DeleteGroup(String groupId,String userId)
        {
            if (UserService.DeleteGroup(Convert.ToInt32(groupId), Convert.ToInt32(userId)))
            {
                return JsonHelper.GetResponseMessage(true, "删除群组成功", null, false, null);
            }
            throw new Exception("删除群组失败");
        }

        /// <summary>
        /// 获取用户所有群组（不包括群组成员)
        /// </summary>
        /// <param name="userId">登录用户</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllGroup(String userId)
        {
            return JsonHelper.GetResponseMessage(true, "获取群组数据成功", typeof(GroupDTO), true, UserService.GetAllGroupByUserId(Convert.ToInt32(userId),false));
            //throw new Exception("获取群组数据失败");
        }

        /// <summary>
        /// 获取所有群组
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllGroup()
        {
            return JsonHelper.GetResponseMessage(true, "获取群组数据成功", typeof(GroupDTO), true, UserService.GetAllGroupByUserId(-1, false));
        }

        /// <summary>
        /// 获取用户所有群组（包括群组成员)
        /// </summary>
        /// <param name="userId">登录用户Id</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllGroupWithMember(String userId)
        {
            return JsonHelper.GetResponseMessage(true, "获取群组数据成功", typeof(GroupDTO), true, UserService.GetAllGroupByUserId(Convert.ToInt32(userId), true));
            //throw new Exception("获取群组数据失败");
        }

        /// <summary>
        /// 获取群组信息
        /// </summary>
        /// <param name="groupId">群组主键</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetGroupById(string groupId)
        {
            return JsonHelper.GetResponseMessage(true, "获取群组数据成功", typeof(GroupDTO), false, UserService.GetGroupById(Convert.ToInt32(groupId)));
            //throw new Exception("获取群组数据失败");
        }

        /// <summary>
        /// 获取群组成员
        /// </summary>
        /// <param name="groupId">群组Id</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetGroupMember(String groupId)
        {
            return JsonHelper.GetResponseMessage(true, "获取群组数据成功", typeof(GroupMemberDTO), true, UserService.GetGroupMembersByGroupId(Convert.ToInt32(groupId)));
            //throw new Exception("获取群组数据失败");
        }

        /// <summary>
        /// 添加群组成员
        /// </summary>
        /// <param name="userId">登录用户</param>
        /// <param name="groupId">群组</param>
        /// <param name="memberUserId">待添加成员userId</param>
        /// <param name="referenceUserId">推荐人Id</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage AddUserToGroup(String userId,String groupId,String memberUserId,String referenceUserId)
        {
            if (UserService.AddUserToGroup(Convert.ToInt32(memberUserId), Convert.ToInt32(groupId), Convert.ToInt32(userId),Convert.ToInt32(referenceUserId)))
            {
                return JsonHelper.GetResponseMessage(true, "添加用户到群组成功", typeof(GroupDTO), false, 
                    UserService.GetAllGroupByUserId(Convert.ToInt32(userId),true).Where(it=>it.Id.ToString().Equals(groupId)).FirstOrDefault());
            }
            throw new Exception("无法添加用户到群组");
        }

        /// <summary>
        /// 移除群组成员
        /// </summary>
        /// <param name="userId">登录用户</param>
        /// <param name="groupId">群组</param>
        /// <param name="groupMemberId">带移除群组成员Id</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage RemoveUserFromGroup(string userId, String groupId, String groupMemberId)
        {
            if (UserService.RemoveUserFromGroup(Convert.ToInt32(groupMemberId), Convert.ToInt32(groupId), Convert.ToInt32(userId)))
            {
                return JsonHelper.GetResponseMessage(true, "移除成功", null, false, null);
            }
            throw new Exception("无法从群组移除数据");
        }


        /// <summary>
        /// 修改群组成员角色
        /// </summary>
        /// <param name="userId">登录用户</param>
        /// <param name="groupId">群组</param>
        /// <param name="groupRole">群角色</param>
        /// <param name="groupMemberId">群组成员</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage ShiftGroupMemberRole(String userId, String groupId, String groupRole, String groupMemberId)
        {
            if (UserService.ShiftGroupMemberRole(Convert.ToInt32(userId), Convert.ToInt32(groupId), groupRole, Convert.ToInt32(groupMemberId)))
            {
                return JsonHelper.GetResponseMessage(true, "修改群组角色成功", typeof(GroupMemberDTO), false, UserService.GetGroupMembersByGroupId(Convert.ToInt32(groupId)));
            }
            throw new Exception("修改失败");
        }

       /// <summary>
       /// 修改群名片
       /// </summary>
       /// <param name="userId">登录用户</param>
       /// <param name="newName">新名称</param>
       /// <param name="groupMemberId">群组成员</param>
       /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage UpdateGroupMemberName(String userId,String newName,String groupMemberId)
        {
            if (UserService.UpdateGroupMemberName(Convert.ToInt32(userId), newName, Convert.ToInt32(groupMemberId)))
            {
                return JsonHelper.GetResponseMessage(true, "修改群组名片成功", typeof(GroupDTO), false, UserService.GetGroupMemberById(Convert.ToInt32(groupMemberId)));
            }
            throw new Exception("修改群组名片失败"); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName">传输文件全名 包括后缀 不含路径</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> UpLoadFile(String fileName)
        {

            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //string root = HttpContext.Current.Server.MapPath("~/App_Data/File/" + DateTime.Now.ToString("yyyyMMddHHmmssffff")+"fromId"+fromId+"toId"+toId+"_path");//指定要将文件存入的服务器物理位置
            string root = HttpContext.Current.Server.MapPath("~/App_Data/Temp");
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                //// Read the form data.  
                //给文件的读写操作加锁，防止在上传同名文件的时候出现问题 
                //lock (_lockObject)
                //{
                //var task = 
                //Request.Content.ReadAsMultipartAsync(provider).ContinueWith(t =>
                //    {
                //        //String path = HttpContext.Current.Server.MapPath("~/app_Data/File");
                //        if (t.IsFaulted || t.IsCanceled)
                //            throw new Exception("文件未上传");
                //        //var fileInfo = provider.FileData.Select(it =>
                //        //{
                //        //    var info = new FileInfo(it.LocalFileName);
                //        //    info.CopyTo(path);
                //        //    info.Delete();
                //        //    return "";
                //        //}
                //        //);
                //        //return path;
                //    });
                var info= await Request.Content.ReadAsMultipartAsync(provider);
                String path = HttpContext.Current.Server.MapPath("~/App_Data/File/");
                //provider.FileData.Select(it => {
                //    FileInfo fileInfo = new FileInfo(it.LocalFileName);
                //    fileInfo.CopyTo(path + FileHelper.Encrept(fileName));
                //    fileInfo.Delete();
                //    return "";
                //});
                FileInfo fileInfo = new FileInfo(provider.FileData[0].LocalFileName);
                fileInfo.CopyTo(path + FileHelper.Encrept(fileName));
                fileInfo.Delete();

                return JsonHelper.GetResponseMessage(true, "文件传输成功", typeof(String), false, path + FileHelper.Encrept(fileName));
                //}
            }
            catch(Exception ex)
            {
                return JsonHelper.GetResponseMessage(false, ex.Message, null, false, null);
            } 
        }

        [HttpGet]
        public HttpResponseMessage DownloadFile(String fileName)
        {
            HttpResponseMessage result = null;

            DirectoryInfo directoryInfo = new DirectoryInfo(HostingEnvironment.MapPath("~/App_Data/File/"));
            FileInfo foundFileInfo = directoryInfo.GetFiles().Where(x => x.Name == fileName).FirstOrDefault();
            if (foundFileInfo != null)
            {
                FileStream fs = new FileStream(foundFileInfo.FullName, FileMode.Open);

                result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StreamContent(fs);
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = foundFileInfo.Name;
            }
            else
            {
                result = new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            return result;
        }

        #endregion

        [HttpGet]
        public HttpResponseMessage GetAllCommunitcatedUserByUserId(String userId)
        {
            return JsonHelper.GetResponseMessage(true, "获取成功", typeof(Int32), true, UserService.GetAllCommunitcatedUserByUserId(Convert.ToInt32(userId)));
        }
    }
}
