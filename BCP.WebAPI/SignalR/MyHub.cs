﻿using BCP.Domain.Service;
using BCP.ViewModel;
using BCP.WebAPI.Controllers;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Providers.Entities;
using Microsoft.Practices.Unity;

namespace BCP.WebAPI.SignalR
{
    /*
     * 
     * 
     * 客户端方法AddUserMessage(from, umd)
     * **/
    /// <summary>
    /// 
    /// </summary>
    public class MyHub:Hub
    {
        public static List<UserDTO> OnLineUser = new List<UserDTO>();
        private static object _lockObject = new object();

        public static void Login(UserDTO userDto)
        {
            lock (_lockObject)
            {
                if (OnLineUser.Where(it => it.ID.Equals(userDto.ID)).FirstOrDefault() == null)
                {
                    OnLineUser.Add(userDto);
                }
            }
        }

        public static void Logout(int userId)
        {
            lock (_lockObject)
            {
                var user = OnLineUser.Where(it => it.ID == userId).FirstOrDefault();
                if (user != null)
                    OnLineUser.Remove(user);
            }
        }

        /// <summary>
        /// 服务端方法
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPwd"></param>
        public bool Login(String userName, String userPwd)
        {
            lock (_lockObject)
            {
                var user = OnLineUser.Where(it => it.UserName.Equals(userName)).FirstOrDefault();
                if (user != null)
                {
                    user.ContextId = Context.ConnectionId;
                    return true;
                }
            }
            return false;
        }

        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            lock (_lockObject)
            {
                var user = OnLineUser.Where(it => it.ContextId != null && it.ContextId.Equals(Context.ConnectionId)).FirstOrDefault();
                if (user != null)
                    user.ContextId = String.Empty;
            }
            return base.OnDisconnected(stopCalled);
        }

        /// <summary>
        /// 服务端方法
        /// </summary>
        /// <param name="replyId"></param>
        /// <param name="message"></param>
        public void PTPSendMessage(int replyId, String message)
        {
            UnityBootStrapper ubs = new UnityBootStrapper();
            ubs.Bindings();
            IUserService userService = (IUserService)ubs.UnityContainer.Resolve(typeof(IUserService));
            lock (_lockObject)
            {
                var from = OnLineUser.Where(it => it.ContextId!=null&&it.ContextId.Equals(Context.ConnectionId)).FirstOrDefault();
                if (from == null) return;
                var to = userService.GetUser(replyId);
                UserMessageDTO umd = new UserMessageDTO() { Content = message, CreateTime = DateTime.Now, EventTime = 1, SenderID = from.ID, ReplyId = to.ID, State = "0" };
                if (userService.AddPTPMessage(umd))
                {
                    to = OnLineUser.Where(it => it.ID == to.ID).FirstOrDefault();
                    if (to != null)
                    {
                        Clients.Client(to.ContextId).AddUserMessage(from, umd);
                    }
                }
            }
        }

        /// <summary>
        /// 服务器方法 标记已读信息
        /// </summary>
        /// <param name="replyId"></param>
        public void PTPMarkMessage(int replyId)
        {
            UnityBootStrapper ubs = new UnityBootStrapper();
            ubs.Bindings();
            IUserService userService = (IUserService)ubs.UnityContainer.Resolve(typeof(IUserService));
            lock (_lockObject)
            {
                var from = OnLineUser.Where(it => it.ContextId != null && it.ContextId.Equals(Context.ConnectionId)).FirstOrDefault();
                userService.MarkPTPMessage(from.ID, replyId);
            }
        }

        public void PTASendMessage()
        {
 
        }

        /// <summary>
        /// 服务端方法
        /// </summary>
        /// <param name="replyId"></param>
        public void InitPTP(int replyId)
        {
            UnityBootStrapper ubs = new UnityBootStrapper();
            ubs.Bindings();
            IUserService userService = (IUserService)ubs.UnityContainer.Resolve(typeof(IUserService));
            lock (_lockObject)
            {
                var from = OnLineUser.Where(it => it.ContextId != null && it.ContextId == Context.ConnectionId).FirstOrDefault();
                if (from == null) return;
                List<UserMessageDTO> message = userService.GetPTPMessage(from.ID, replyId).Where(it=>it.State.Equals("0")).ToList();
                foreach (var node in message)
                {
                    if (node.SenderID == from.ID)
                    {
                        Clients.Client(from.ContextId).AddUserMessage(from, node);
                    }
                    else
                    {
                        if (node.ReplyId != null)
                        {
                            var to = userService.GetUser((int)node.SenderID);
                            Clients.Client(from.ContextId).AddUserMessage(to, node);
                        }
                    }
                }
            }
        }

        public void InitPTA()
        { }

        /// <summary>
        /// 服务器方法 按日期获取聊天记录
        /// data=yyyy-mm-dd
        /// </summary>
        /// <param name="replyId"></param>
        /// <param name="date"></param>
        public void GetPTPMessage(int replyId, String date)
        {
            UnityBootStrapper ubs = new UnityBootStrapper();
            ubs.Bindings();
            IUserService userService = (IUserService)ubs.UnityContainer.Resolve(typeof(IUserService));
            int year = Convert.ToInt32(date.Split('-')[0]);
            int month = Convert.ToInt32(date.Split('-')[1]);
            int day = Convert.ToInt32(date.Split('-')[2]);
            lock (_lockObject)
            {
                var from = OnLineUser.Where(it => it.ContextId != null && it.ContextId == Context.ConnectionId).FirstOrDefault();
                if (from == null) return;
                List<UserMessageDTO> message = userService.GetPTPMessage(from.ID, replyId).Where(it => it.CreateTime.Year==year&&it.CreateTime.Month==month&&it.CreateTime.Day==day).ToList();
                foreach (var node in message)
                {
                    if (node.SenderID == from.ID)
                    {
                        Clients.Client(from.ContextId).AddUserMessage(from, node);
                    }
                    else
                    {
                        if (node.ReplyId != null)
                        {
                            var to = userService.GetUser((int)node.SenderID);
                            Clients.Client(from.ContextId).AddUserMessage(to, node);
                        }
                    }
                }
            }
        }
    }
}