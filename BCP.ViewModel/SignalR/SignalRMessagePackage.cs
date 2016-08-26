using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BCP.WebAPI.SignalR
{

    /// <summary>
    /// 信息类型 
    /// </summary>
    public enum SignalRMessageType
    {
        Doc,
        Pic,
        Text,
        [Description("状态信息")]
        StateMessage
    }

    /// <summary>
    /// 通讯方式
    /// </summary>
    public enum SignalRCommunicationType
    {
        [Description("点对点通讯")]
        PersonToPerson,
        [Description("点对群通讯")]
        PersonToGroup
    }
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
    }

    /// <summary>
    /// 点对群组文字通讯包
    /// </summary>
    public class PTGTextPackage : SignalRMessagePackage
    {
        public PTGTextPackage(String context, int fromUserId, int groupId)
        {
            this.Context = context;
            this.FromUserId = fromUserId;
            this.SCType = SignalRCommunicationType.PersonToGroup;
            this.SMType = SignalRMessageType.Text;
            this.ToUserId = groupId;
        }
    }
}