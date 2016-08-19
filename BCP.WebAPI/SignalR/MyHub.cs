using BCP.Domain.Service;
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
     *           AddPTGMessage(UserDTO sender,String groupId,CommunitcationPackage cp)
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
                var sender = OnLineUser.Where(it => it.ContextId!=null&&it.ContextId.Equals(Context.ConnectionId)).FirstOrDefault();
                if (sender == null) return;
                var recevier = userService.GetUser(replyId);
                UserMessageDTO umd = new UserMessageDTO() { Content = message, CreateTime = DateTime.Now, EventTime = 1, SenderID = sender.ID, ReplyId = recevier.ID, State = "0" };
                if (userService.AddPTPMessage(umd))
                {
                    recevier = OnLineUser.Where(it => it.ID == recevier.ID).FirstOrDefault();
                    if (recevier != null)
                    {
                        Clients.Client(recevier.ContextId).AddUserMessage(sender, umd);
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
                var sender = OnLineUser.Where(it => it.ContextId != null && it.ContextId.Equals(Context.ConnectionId)).FirstOrDefault();
                userService.MarkPTPMessage(sender.ID, replyId);
            }
        }

        /// <summary>
        /// 服务器方法 发送群组消息
        /// </summary>
        /// <param name="groupId"></param>
        public void PTGSenderMessage(int groupId,CommunitcationPackage cp)
        {
            UnityBootStrapper ubs = new UnityBootStrapper();
            ubs.Bindings();
            IUserService userService = (IUserService)ubs.UnityContainer.Resolve(typeof(IUserService));
            lock (_lockObject)
            {
                if (cp.MType == MessageType.Text)
                {
                    var sender = OnLineUser.Where(it => it.ContextId != null && it.ContextId.Equals(Context.ConnectionId)).FirstOrDefault();
                    if (sender == null)
                    {
                        return;
                    }
                    GroupMessagerDTO gmt = new GroupMessagerDTO() { Content = cp.Content.ToString(), GroupID = groupId, Type = MessageType.Text.ToString(), SendTime = cp.SendTime.ToString() };
                    if (userService.AddGroupMessage(gmt, sender.ID))
                    {
                        foreach (var node in OnLineUser)
                        {
                            if (node.Groups.Where(it => it.ID == groupId).FirstOrDefault() != null && node.ContextId != null)
                            {
                                Clients.Client(node.ContextId).AddPTGMessage(sender, cp);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 服务器方法 标记已读数据
        /// </summary>
        public void PTGMarkMessage()
        {
            UnityBootStrapper ubs = new UnityBootStrapper();
            ubs.Bindings();
            IUserService userService = (IUserService)ubs.UnityContainer.Resolve(typeof(IUserService));
            lock (_lockObject)
            {
                var sender = OnLineUser.Where(it => it.ContextId != null && it.ContextId.Equals(Context.ConnectionId)).FirstOrDefault();
                if (sender == null) return;
                userService.MarkPTGMessage(sender.ID);
                //未完成
            }
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
                var sender = OnLineUser.Where(it => it.ContextId != null && it.ContextId == Context.ConnectionId).FirstOrDefault();
                if (sender == null) return;
                List<UserMessageDTO> message = userService.GetPTPMessage(sender.ID, replyId).Where(it => it.State.Equals("0")).ToList();
                foreach (var node in message)
                {
                    if (node.SenderID == sender.ID)
                    {
                        Clients.Client(sender.ContextId).AddUserMessage(sender, node);
                    }
                    else
                    {
                        if (node.ReplyId != null)
                        {
                            var recevier = userService.GetUser((int)node.SenderID);
                            Clients.Client(sender.ContextId).AddUserMessage(recevier, node);
                        }
                    }
                }
            }
        }

        public void InitPTG() {
            UnityBootStrapper ubs = new UnityBootStrapper();
            ubs.Bindings();
            IUserService userService = (IUserService)ubs.UnityContainer.Resolve(typeof(IUserService));
            lock (_lockObject)
            {
                var sender = OnLineUser.Where(it => it.ContextId != null && it.ContextId.Equals(Context.ConnectionId)).FirstOrDefault();
                if (sender == null) return;
                List<GroupMessagerDTO> list = userService.GetPTGMessage(sender.ID);
                foreach (var node in list)
                {
                    CommunitcationPackage cp = new CommunitcationPackage();
                    if (node.Type == MessageType.Text.ToString())
                    {
                        cp.Content = node.Content;
                        cp.MType = MessageType.Text;
                        cp.CType = CommunitcationType.PersonToGroup;
                        cp.SendTime = Convert.ToDateTime(node.SendTime);
                    }
                    Clients.Client(Context.ConnectionId).AddPTGMessage(sender, cp);
                }
            }
        }

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
                var sender = OnLineUser.Where(it => it.ContextId != null && it.ContextId == Context.ConnectionId).FirstOrDefault();
                if (sender == null) return;
                List<UserMessageDTO> message = userService.GetPTPMessage(sender.ID, replyId).Where(it => it.CreateTime.Year == year && it.CreateTime.Month == month && it.CreateTime.Day == day).ToList();
                foreach (var node in message)
                {
                    if (node.SenderID == sender.ID)
                    {
                        Clients.Client(sender.ContextId).AddUserMessage(sender, node);
                    }
                    else
                    {
                        if (node.ReplyId != null)
                        {
                            var recevier = userService.GetUser((int)node.SenderID);
                            Clients.Client(sender.ContextId).AddUserMessage(recevier, node);
                        }
                    }
                }
            }
        }

        public void GetPTGMessage()
        { }
    }


    public class CHun
    {
        public static List<UserDTO> OnLineUser = new List<UserDTO>();
        private static object _lockObject = new object();

        #region ApiInterface

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

        #endregion

        #region override
        //public override Task OnConnected()
        //{
        //    return base.OnConnected();
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    base.Dispose(disposing);
        //}

        //public override Task OnDisconnected(bool stopCalled)
        //{
        //    return base.OnDisconnected(stopCalled);
        //}
        #endregion

        #region ServerInterface

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

        public void SendMessage()
        { }

        public void MarkMessage()
        { }

        public void GetAllMessage()
        { }

        public void GetUnMarkedMessage()
        { }

        #endregion
    }
}