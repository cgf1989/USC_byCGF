using BCP.Domain.Service;
using Microsoft.Practices.Unity;
using BCP.ViewModel;
using BCP.WebAPI.Controllers;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BCP.WebAPI.SignalR
{
    /// <summary>
    /// 通讯包 虚类
    /// </summary>
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

        /// <summary>
        /// 信息发送方法
        /// </summary>
        /// <param name="Clients"></param>
        /// <param name="Context"></param>
        /// <param name="hub"></param>
        public abstract void SendMessage(IHubCallerConnectionContext<dynamic> Clients, HubCallerContext Context, MyHub hub);

        /// <summary>
        /// 信息标记方法
        /// </summary>
        /// <param name="Clients"></param>
        /// <param name="Context"></param>
        /// <param name="hub"></param>
        public abstract void MarkMessage(IHubCallerConnectionContext<dynamic> Clients, HubCallerContext Context, MyHub hub);

        /// <summary>
        /// 取出未读信息方法
        /// </summary>
        /// <param name="Clients"></param>
        /// <param name="Context"></param>
        /// <param name="hub"></param>
        public abstract void InitClient(IHubCallerConnectionContext<dynamic> Clients, HubCallerContext Context, MyHub hub);

        /// <summary>
        /// 获取所有信息方法
        /// </summary>
        /// <param name="Clients"></param>
        /// <param name="Context"></param>
        /// <param name="hub"></param>
        /// <param name="date"></param>
        public abstract void GetAllMessage(IHubCallerConnectionContext<dynamic> Clients, HubCallerContext Context, MyHub hub,DateTime date);
    }

    /// <summary>
    /// 点对点 文字通讯包类
    /// </summary>
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
                    State = 0,
                    MessageType=(int)this.SMType
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
            UnityBootStrapper ubs = new UnityBootStrapper();
            ubs.Bindings();
            IUserService userService = (IUserService)ubs.UnityContainer.Resolve(typeof(IUserService));
            //var from = hub.Get();
            try
            {
                userService.MarkPTPMessage(this.FromUserId, this.ToUserId);
            }
            catch (Exception ex)
            { }
        }

        public override void InitClient(IHubCallerConnectionContext<dynamic> Clients, HubCallerContext Context, MyHub hub)
        {
            UnityBootStrapper ubs = new UnityBootStrapper();
            ubs.Bindings();
            IUserService userService = (IUserService)ubs.UnityContainer.Resolve(typeof(IUserService));
            var from = hub.Get();
            List<UserMessageDTO> message = userService.GetPTPMessage(this.FromUserId, this.ToUserId).Where(it => it.State == 0).ToList();
            foreach (var node in message)
            {
                if (node.MessageType != (int)SignalRMessageType.Text) continue;
                if (node.FromUserId == this.FromUserId)
                {
                    Clients.Client(from.ContextId)
                        .ReceviceMessage(new PTPTextPackage(node.Content, this.FromUserId, this.ToUserId));
                }
                else
                {
                    Clients.Client(from.ContextId)
                        .ReceviceMessage(new PTPTextPackage(node.Content, this.ToUserId, this.FromUserId));
                }
            }
        }

        public override void GetAllMessage(IHubCallerConnectionContext<dynamic> Clients, HubCallerContext Context, MyHub hub,DateTime date)
        {
            UnityBootStrapper ubs = new UnityBootStrapper();
            ubs.Bindings();
            IUserService userService = (IUserService)ubs.UnityContainer.Resolve(typeof(IUserService));
            var from = hub.Get();
            List<UserMessageDTO> message = userService.GetPTPMessage(this.FromUserId, this.ToUserId).Where(it =>it.CreateTime!=null&&it.CreateTime.Value.Year==date.Year&&it.CreateTime.Value.Month==date.Month&&it.CreateTime.Value.Day==date.Day).ToList();
            foreach (var node in message)
            {
                if (node.MessageType != (int)SignalRMessageType.Text) continue;
                if (node.FromUserId == this.FromUserId)
                {
                    Clients.Client(from.ContextId)
                        .ReceviceMessage(new PTPTextPackage(node.Content, this.FromUserId, this.ToUserId));
                }
                else
                {
                    Clients.Client(from.ContextId)
                        .ReceviceMessage(new PTPTextPackage(node.Content, this.ToUserId, this.FromUserId));
                }
            }
        }
    }

    /// <summary>
    /// 信息状态通讯包类
    /// 用途：发送信息时，验证信息是否发送成功；
    /// </summary>
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

        public override void GetAllMessage(IHubCallerConnectionContext<dynamic> Clients, HubCallerContext Context, MyHub hub,DateTime date)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 点对群组文字通讯包
    /// </summary>
    public class PTGTextPackage : SignalRMessagePackage
    {
        public PTGTextPackage(String context,int fromUserId,int groupId)
        {
            this.Context = context;
            this.FromUserId =fromUserId;
            this.SCType = SignalRCommunicationType.PersonToGroup;
            this.SMType = SignalRMessageType.Text;
            this.ToUserId = groupId;
        }

        public override void SendMessage(IHubCallerConnectionContext<dynamic> Clients, HubCallerContext Context, MyHub hub)
        {
            UnityBootStrapper ubs = new UnityBootStrapper();
            ubs.Bindings();
            IUserService userService = (IUserService)ubs.UnityContainer.Resolve(typeof(IUserService));
            try
            {
                //数据验证
                var from = hub.Get();
                var to = userService.GetGroupById(this.ToUserId);
                if(from==null||to==null)
                    Clients.Client(Context.ConnectionId)
                        .ReceviceMessage(new StatePackage(from == null ? "发送者不在线" : to == null ? "接收方不存在" : "",
                        this.FromUserId, this.ToUserId, this.SCType, false));

                //信息处理
                GroupMessagerDTO gmd = new GroupMessagerDTO()
                {
                    Content = this.Context.ToString(),
                    GroupId = to.Id,
                    MessageType = (int)this.SMType,
                    CrateTime = DateTime.Now,
                    CrateUseId = this.FromUserId
                };
                if (userService.AddGroupMessage(gmd, this.FromUserId))
                {
                    foreach (var node in hub.GetAllOnLineUser())
                    {
                        if (node.Groups != null && node.Groups.Where(it => it.Id == this.ToUserId).FirstOrDefault() != null && !String.IsNullOrWhiteSpace(node.ContextId))
                        {
                            Clients.Client(node.ContextId)
                            .ReceviceMessage(new PTGTextPackage(this.Context.ToString(),this.FromUserId,this.ToUserId));
                        }
                    }
                }

                //通知发送方 信息发送成功
                Clients.Client(Context.ConnectionId)
                    .ReceviceMessage(new StatePackage("",
                    this.FromUserId, this.ToUserId, this.SCType, true));
            }
            catch (Exception ex)
            {
                //通知发送方 信息发送失败
                Clients.Client(Context.ConnectionId)
                .ReceviceMessage(new StatePackage(ex.Message,
                this.FromUserId, this.ToUserId, this.SCType, false));
            }
        }

        public override void MarkMessage(IHubCallerConnectionContext<dynamic> Clients, HubCallerContext Context, MyHub hub)
        {

        }

        public override void InitClient(IHubCallerConnectionContext<dynamic> Clients, HubCallerContext Context, MyHub hub)
        {
            UnityBootStrapper ubs = new UnityBootStrapper();
            ubs.Bindings();
            IUserService userService = (IUserService)ubs.UnityContainer.Resolve(typeof(IUserService));
            try
            {
                var from = hub.Get();
                List<GroupMessagerDTO> list = userService.GetPTGMessage(from.ID).Where(it=>it.CrateTime!=null&&it.CrateTime.Value.Year==DateTime.Now.Year&&it.CrateTime.Value.Month==DateTime.Now.Month&&it.CrateTime.Value.Day==DateTime.Now.Day).ToList();
                foreach (var node in list)
                {
                    if (node.MessageType == (int)SignalRMessageType.Text)
                    {
                        Clients.Client(Context.ConnectionId)
                            .ReceviceMessage(new PTGTextPackage(node.Content,this.FromUserId,(int)node.GroupId));
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        public override void GetAllMessage(IHubCallerConnectionContext<dynamic> Clients, HubCallerContext Context, MyHub hub, DateTime date)
        {
            UnityBootStrapper ubs = new UnityBootStrapper();
            ubs.Bindings();
            IUserService userService = (IUserService)ubs.UnityContainer.Resolve(typeof(IUserService));
            try
            {
                var from = hub.Get();
                List<GroupMessagerDTO> list = userService.GetPTGMessage(from.ID).Where(it => it.CrateTime != null && it.CrateTime.Value.Year == date.Year && it.CrateTime.Value.Month == date.Month && it.CrateTime.Value.Day == date.Day).ToList();
                foreach (var node in list)
                {
                    if (node.MessageType == (int)SignalRMessageType.Text)
                    {
                        Clients.Client(Context.ConnectionId)
                            .ReceviceMessage(new PTGTextPackage(node.Content, this.FromUserId, (int)node.GroupId));
                    }
                }
            }
            catch (Exception ex)
            { }
        }
    }
}