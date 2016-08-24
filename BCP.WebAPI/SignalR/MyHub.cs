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
using System.ComponentModel;
using Microsoft.AspNet.SignalR.Hubs;

namespace BCP.WebAPI.SignalR
{
    ///*
    // * 
    // * 
    // * 客户端方法AddUserMessage(from, umd)
    // *           AddPTGMessage(UserDTO sender,String groupId,CommunitcationPackage cp)
    // * **/
    ///// <summary>
    ///// 
    ///// </summary>
    //public class MyHub : Hub
    //{
    //    public static List<UserDTO> OnLineUser = new List<UserDTO>();
    //    private static object _lockObject = new object();

    //    public static void Login(UserDTO userDto)
    //    {
    //        lock (_lockObject)
    //        {
    //            if (OnLineUser.Where(it => it.ID.Equals(userDto.ID)).FirstOrDefault() == null)
    //            {
    //                OnLineUser.Add(userDto);
    //            }
    //        }
    //    }

    //    public static void Logout(int userId)
    //    {
    //        lock (_lockObject)
    //        {
    //            var user = OnLineUser.Where(it => it.ID == userId).FirstOrDefault();
    //            if (user != null)
    //                OnLineUser.Remove(user);
    //        }
    //    }

    //    public static void UpdateOnLineUser(UserDTO user)
    //    {
    //        if (user == null) return;
    //        lock (_lockObject)
    //        {
    //            var old = OnLineUser.Where(it => it.ID == user.ID).FirstOrDefault();
    //            if (old != null)
    //            {
    //                user.ContextId = old.ContextId;
    //                OnLineUser.Remove(old);
    //                OnLineUser.Add(user);
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// 服务端方法
    //    /// </summary>
    //    /// <param name="userName"></param>
    //    /// <param name="userPwd"></param>
    //    public bool Login(String userName, String userPwd)
    //    {
    //        lock (_lockObject)
    //        {
    //            var user = OnLineUser.Where(it => it.UserName.Equals(userName)).FirstOrDefault();
    //            if (user != null)
    //            {
    //                user.ContextId = Context.ConnectionId;
    //                return true;
    //            }
    //        }
    //        return false;
    //    }

    //    public override Task OnConnected()
    //    {
    //        return base.OnConnected();
    //    }

    //    public override Task OnDisconnected(bool stopCalled)
    //    {
    //        lock (_lockObject)
    //        {
    //            var user = OnLineUser.Where(it => it.ContextId != null && it.ContextId.Equals(Context.ConnectionId)).FirstOrDefault();
    //            if (user != null)
    //                user.ContextId = String.Empty;
    //        }
    //        return base.OnDisconnected(stopCalled);
    //    }

    //    /// <summary>
    //    /// 服务端方法
    //    /// </summary>
    //    /// <param name="replyId"></param>
    //    /// <param name="message"></param>
    //    public void PTPSendMessage(int replyId, String message)
    //    {
    //        UnityBootStrapper ubs = new UnityBootStrapper();
    //        ubs.Bindings();
    //        IUserService userService = (IUserService)ubs.UnityContainer.Resolve(typeof(IUserService));
    //        lock (_lockObject)
    //        {
    //            var sender = OnLineUser.Where(it => it.ContextId != null && it.ContextId.Equals(Context.ConnectionId)).FirstOrDefault();
    //            if (sender == null) return;
    //            var recevier = userService.GetUser(replyId);
    //            UserMessageDTO umd = new UserMessageDTO() { Content = message, CreateTime = DateTime.Now, FromUserId = sender.ID, ToUserId = recevier.ID, State = 0 };
    //            if (userService.AddPTPMessage(umd))
    //            {
    //                recevier = OnLineUser.Where(it => it.ID == recevier.ID).FirstOrDefault();
    //                if (recevier != null)
    //                {
    //                    Clients.Client(recevier.ContextId).AddUserMessage(sender, umd);
    //                }
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// 服务器方法 标记已读信息
    //    /// </summary>
    //    /// <param name="replyId"></param>
    //    public void PTPMarkMessage(int replyId)
    //    {
    //        UnityBootStrapper ubs = new UnityBootStrapper();
    //        ubs.Bindings();
    //        IUserService userService = (IUserService)ubs.UnityContainer.Resolve(typeof(IUserService));
    //        lock (_lockObject)
    //        {
    //            var sender = OnLineUser.Where(it => it.ContextId != null && it.ContextId.Equals(Context.ConnectionId)).FirstOrDefault();
    //            userService.MarkPTPMessage(sender.ID, replyId);
    //        }
    //    }

    //    /// <summary>
    //    /// 服务器方法 发送群组消息
    //    /// </summary>
    //    /// <param name="groupId"></param>
    //    public void PTGSenderMessage(int groupId, CommunitcationPackage cp)
    //    {
    //        UnityBootStrapper ubs = new UnityBootStrapper();
    //        ubs.Bindings();
    //        IUserService userService = (IUserService)ubs.UnityContainer.Resolve(typeof(IUserService));
    //        lock (_lockObject)
    //        {
    //            if (cp.MType == MessageType.Text)
    //            {
    //                var sender = OnLineUser.Where(it => it.ContextId != null && it.ContextId.Equals(Context.ConnectionId)).FirstOrDefault();
    //                if (sender == null)
    //                {
    //                    return;
    //                }
    //                GroupMessagerDTO gmt = new GroupMessagerDTO() { Content = cp.Content.ToString(), GroupId = groupId, MessageType = (int)MessageType.Text, CrateTime = cp.SendTime };
    //                if (userService.AddGroupMessage(gmt, sender.ID))
    //                {
    //                    foreach (var node in OnLineUser)
    //                    {
    //                        if (node.Groups.Where(it => it.Id == groupId).FirstOrDefault() != null && node.ContextId != null)
    //                        {
    //                            Clients.Client(node.ContextId).AddPTGMessage(sender, cp);
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// 服务器方法 标记已读数据
    //    /// </summary>
    //    public void PTGMarkMessage()
    //    {
    //        UnityBootStrapper ubs = new UnityBootStrapper();
    //        ubs.Bindings();
    //        IUserService userService = (IUserService)ubs.UnityContainer.Resolve(typeof(IUserService));
    //        lock (_lockObject)
    //        {
    //            var sender = OnLineUser.Where(it => it.ContextId != null && it.ContextId.Equals(Context.ConnectionId)).FirstOrDefault();
    //            if (sender == null) return;
    //            userService.MarkPTGMessage(sender.ID);
    //            //未完成
    //        }
    //    }

    //    /// <summary>
    //    /// 服务端方法
    //    /// </summary>
    //    /// <param name="replyId"></param>
    //    public void InitPTP(int replyId)
    //    {
    //        UnityBootStrapper ubs = new UnityBootStrapper();
    //        ubs.Bindings();
    //        IUserService userService = (IUserService)ubs.UnityContainer.Resolve(typeof(IUserService));
    //        lock (_lockObject)
    //        {
    //            var sender = OnLineUser.Where(it => it.ContextId != null && it.ContextId == Context.ConnectionId).FirstOrDefault();
    //            if (sender == null) return;
    //            List<UserMessageDTO> message = userService.GetPTPMessage(sender.ID, replyId).Where(it => it.State.Equals("0")).ToList();
    //            foreach (var node in message)
    //            {
    //                if (node.FromUserId == sender.ID)
    //                {
    //                    Clients.Client(sender.ContextId).AddUserMessage(sender, node);
    //                }
    //                else
    //                {
    //                    if (node.ToUserId != null)
    //                    {
    //                        var recevier = userService.GetUser((int)node.FromUserId);
    //                        Clients.Client(sender.ContextId).AddUserMessage(recevier, node);
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    public void InitPTG()
    //    {
    //        UnityBootStrapper ubs = new UnityBootStrapper();
    //        ubs.Bindings();
    //        IUserService userService = (IUserService)ubs.UnityContainer.Resolve(typeof(IUserService));
    //        lock (_lockObject)
    //        {
    //            var sender = OnLineUser.Where(it => it.ContextId != null && it.ContextId.Equals(Context.ConnectionId)).FirstOrDefault();
    //            if (sender == null) return;
    //            List<GroupMessagerDTO> list = userService.GetPTGMessage(sender.ID);
    //            foreach (var node in list)
    //            {
    //                CommunitcationPackage cp = new CommunitcationPackage();
    //                if (node.MessageType == (int)MessageType.Text)
    //                {
    //                    cp.Content = node.Content;
    //                    cp.MType = MessageType.Text;
    //                    cp.CType = CommunitcationType.PersonToGroup;
    //                    cp.SendTime = Convert.ToDateTime(node.CrateTime);
    //                }
    //                Clients.Client(Context.ConnectionId).AddPTGMessage(sender, cp);
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// 服务器方法 按日期获取聊天记录
    //    /// data=yyyy-mm-dd
    //    /// </summary>
    //    /// <param name="replyId"></param>
    //    /// <param name="date"></param>
    //    public void GetPTPMessage(int replyId, String date)
    //    {
    //        UnityBootStrapper ubs = new UnityBootStrapper();
    //        ubs.Bindings();
    //        IUserService userService = (IUserService)ubs.UnityContainer.Resolve(typeof(IUserService));
    //        int year = Convert.ToInt32(date.Split('-')[0]);
    //        int month = Convert.ToInt32(date.Split('-')[1]);
    //        int day = Convert.ToInt32(date.Split('-')[2]);
    //        lock (_lockObject)
    //        {
    //            var sender = OnLineUser.Where(it => it.ContextId != null && it.ContextId == Context.ConnectionId).FirstOrDefault();
    //            if (sender == null) return;
    //            List<UserMessageDTO> message = userService.GetPTPMessage(sender.ID, replyId).Where(it => it.CreateTime != null
    //            && it.CreateTime.Value.Year == year && it.CreateTime.Value.Month == month && it.CreateTime.Value.Day == day).ToList();
    //            foreach (var node in message)
    //            {
    //                if (node.FromUserId == sender.ID)
    //                {
    //                    Clients.Client(sender.ContextId).AddUserMessage(sender, node);
    //                }
    //                else
    //                {
    //                    if (node.ToUserId != null)
    //                    {
    //                        var recevier = userService.GetUser((int)node.FromUserId);
    //                        Clients.Client(sender.ContextId).AddUserMessage(recevier, node);
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    public void GetPTGMessage()
    //    { }
    //}


    public class MyHub : Hub
    {
        public static List<UserDTO> OnLineUser = new List<UserDTO>();
        public static object _lockObject = new object();

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

        public static void UpdateOnLineUser(UserDTO user)
        {
            if (user == null) return;
            lock (_lockObject)
            {
                var old = OnLineUser.Where(it => it.ID == user.ID).FirstOrDefault();
                if (old != null)
                {
                    user.ContextId = old.ContextId;
                    OnLineUser.Remove(old);
                    OnLineUser.Add(user);
                }
            }
        }

        public UserDTO Get(int id)
        {
            lock (_lockObject)
            {
                return OnLineUser.Where(it => it.ID == id).FirstOrDefault();
            }
        }

        public UserDTO Get()
        {
            return OnLineUser.Where(it => it.ContextId != null && it.ContextId == Context.ConnectionId).FirstOrDefault();
        }

        #endregion

        #region override

        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }
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

        public void SendMessage(SignalRMessagePackage package)
        {
            //数据验证
            if (package == null)
            {
                Clients.Client(Context.ConnectionId)
                    .ReceviceMessage(new StatePackage("数据包为空", package.FromUserId, package.ToUserId, package.SCType, false));
            }
            package.SendMessage(Clients, Context, this);
        }

        public void MarkMessage()
        { }

        public void GetAllMessage()
        { }

        public void InitClient()
        { }

        #endregion

        #region PrivateMethod


        #endregion
    }

    public abstract class SignalRMessagePackage
    {
        /// <summary>
        /// 通信类型 PersonToPerson PersonToGroup
        /// </summary>
        public SignalRCommunicationType SCType { get; set; }

        /// <summary>
        /// 消息类型 Doc Pic Text Video
        /// </summary>
        public SignalRMessageType SMType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object Context { get; set; }

        /// <summary>
        /// 文档、图片等使用
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// 发送者Id
        /// </summary>
        public int FromUserId { get; set; }

        /// <summary>
        /// 接收方Id(用户或群组Id0
        /// </summary>
        public int ToUserId { get; set; }

        /// <summary>
        /// 信息发送是否成功
        /// </summary>
        public bool State { get; set; }

        public bool Validate()
        {
            return true;
        }

        public abstract void SendMessage(IHubCallerConnectionContext<dynamic> Clients, HubCallerContext Context, MyHub hub);
        public abstract void MarkMessage(IHubCallerConnectionContext<dynamic> Clients, HubCallerContext Context, MyHub hub);
        public abstract void InitClient(IHubCallerConnectionContext<dynamic> Clients, HubCallerContext Context, MyHub hub);
        public abstract void GetAllMessage(IHubCallerConnectionContext<dynamic> Clients, HubCallerContext Context, MyHub hub);
    }

    public enum SignalRMessageType
    {
        Doc, Pic, Text,
        [Description("状态信息")]
        StateMessage
    }

    public enum SignalRCommunicationType
    {
        PersonToPerson, PersonToGroup
    }

    public class PTPTextPackage : SignalRMessagePackage
    {
        /// <summary>
        /// 点对点文字通信
        /// </summary>
        /// <param name="context">信息字符串</param>
        /// <param name="fromUserId">发送者Id</param>
        /// <param name="toUserId">接受者Id</param>
        public PTPTextPackage(String context, int fromUserId, int toUserId)
        {
            this.Context = context;
            this.Title = String.Empty;
            this.FromUserId = fromUserId;
            this.ToUserId = toUserId;
            this.SCType = SignalRCommunicationType.PersonToPerson;
            this.SMType = SignalRMessageType.Text;
        }

        public override void SendMessage(IHubCallerConnectionContext<dynamic> Clients, HubCallerContext Context, MyHub hub)
        {
            UnityBootStrapper ubs = new UnityBootStrapper();
            ubs.Bindings();
            IUserService userService = (IUserService)ubs.UnityContainer.Resolve(typeof(IUserService));
            var from = hub.Get();
            var to = hub.Get(this.ToUserId);
            //数据验证
            if (from == null || to == null)
                Clients.Client(Context.ConnectionId)
                    .ReceviceMessage(new StatePackage(from == null ? "发送者不在线" : to == null ? "接收方不存在" : "",
                        this.FromUserId, this.ToUserId, this.SCType, false));

            try
            {
                //存储发送信息
                if (userService.AddPTPMessage(new UserMessageDTO()
                {
                    Content = this.Context.ToString(),
                    CreateTime = DateTime.Now,
                    ToUserId = to.ID,
                    FromUserId = from.ID,
                    State = 0
                }))
                {
                    //将信息发送给接受者 如果接受者在线
                    //to = OnLineUser.Where(it => it.ID == recevier.ID && String.IsNullOrWhiteSpace(it.ContextId)).FirstOrDefault();
                    to = hub.Get(ToUserId);
                    if (to != null && !String.IsNullOrWhiteSpace(to.ContextId)) Clients.Client(to.ContextId)
                          .ReceviceMessage(new PTPTextPackage(this.Context.ToString(), this.FromUserId, this.ToUserId));

                    //通知发送者 信息发送成功
                    Clients.Client(Context.ConnectionId)
                        .ReceviceMessage(new StatePackage("", this.FromUserId, this.ToUserId, this.SCType, true));
                }
            }
            catch (Exception ex)
            {
                //通知发送者 信息发送失败
                Clients.Client(Context.ConnectionId)
                    .ReceviceMessage(new StatePackage(ex.Message, this.FromUserId, this.ToUserId, this.SCType, false));
            }
        }

        public override void MarkMessage(IHubCallerConnectionContext<dynamic> Clients, HubCallerContext Context, MyHub hub)
        {
            throw new NotImplementedException();
        }

        public override void InitClient(IHubCallerConnectionContext<dynamic> Clients, HubCallerContext Context, MyHub hub)
        {
            throw new NotImplementedException();
        }

        public override void GetAllMessage(IHubCallerConnectionContext<dynamic> Clients, HubCallerContext Context, MyHub hub)
        {
            throw new NotImplementedException();
        }
    }

    public class StatePackage : SignalRMessagePackage
    {
        /// <summary>
        /// 创建状态信息
        /// </summary>
        /// <param name="context"></param>
        /// <param name="fromId">发送者Id</param>
        /// <param name="toId">接受者Id</param>
        /// <param name="sCType">通信方式</param>
        /// <param name="state">状态</param>
        public StatePackage(String context, int fromId, int toId, SignalRCommunicationType sCType, bool state)
        {
            this.Context = context;
            this.FromUserId = fromId;
            this.ToUserId = toId;
            this.SCType = sCType;
            this.SMType = SignalRMessageType.StateMessage;
            this.State = state;
            this.Title = String.Empty;
        }

        public override void SendMessage(IHubCallerConnectionContext<dynamic> Clients, HubCallerContext Context, MyHub hub)
        {
            throw new NotImplementedException();
        }

        public override void MarkMessage(IHubCallerConnectionContext<dynamic> Clients, HubCallerContext Context, MyHub hub)
        {
            throw new NotImplementedException();
        }

        public override void InitClient(IHubCallerConnectionContext<dynamic> Clients, HubCallerContext Context, MyHub hub)
        {
            throw new NotImplementedException();
        }

        public override void GetAllMessage(IHubCallerConnectionContext<dynamic> Clients, HubCallerContext Context, MyHub hub)
        {
            throw new NotImplementedException();
        }
    }
}