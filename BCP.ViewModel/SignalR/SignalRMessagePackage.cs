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
    public class SignalRMessagePackage
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
    /// 工厂方法 构造不同的通讯包
    /// </summary>
    public class SignalRMessagePackageFactory
    {
        /// <summary>
        /// 点对点文字通信
        /// </summary>
        /// <param name="context">信息字符串</param>
        /// <param name="fromUserId">发送者Id</param>
        /// <param name="toUserId">接受者Id</param>
        public static SignalRMessagePackage GetPTPTextPackage(String context, int fromUserId, int toUserId)
        {
            SignalRMessagePackage srm = new SignalRMessagePackage();
            srm.Context = context;
            srm.Title = String.Empty;
            srm.FromUserId = fromUserId;
            srm.ToUserId = toUserId;
            srm.SCType = SignalRCommunicationType.PersonToPerson;
            srm.SMType = SignalRMessageType.Text;
            return srm;
        }

        /// <summary>
        /// 创建状态信息
        /// </summary>
        /// <param name="context"></param>
        /// <param name="fromId">发送者Id</param>
        /// <param name="toId">接受者Id</param>
        /// <param name="sCType">通信方式</param>
        /// <param name="state">状态</param>
        public static SignalRMessagePackage GetStatePackage(String context, int fromId, int toId, SignalRCommunicationType sCType, bool state)
        {
            SignalRMessagePackage srm = new SignalRMessagePackage();
            srm.Context = context;
            srm.FromUserId = fromId;
            srm.ToUserId = toId;
            srm.SCType = sCType;
            srm.SMType = SignalRMessageType.StateMessage;
            srm.State = state;
            srm.Title = String.Empty;
            return srm;
        }

        /// <summary>
        /// 点对群通讯包
        /// </summary>
        /// <param name="context"></param>
        /// <param name="fromUserId"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public static SignalRMessagePackage GetPTGTextPackage(String context, int fromUserId, int groupId)
        {
            SignalRMessagePackage srm = new SignalRMessagePackage();
            srm.Context = context;
            srm.FromUserId = fromUserId;
            srm.SCType = SignalRCommunicationType.PersonToGroup;
            srm.SMType = SignalRMessageType.Text;
            srm.ToUserId = groupId;
            return srm;
        }
    }
}