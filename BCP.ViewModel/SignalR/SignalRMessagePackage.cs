using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using BCP.Common.Helper;
using BCP.ViewModel;

namespace BCP.WebAPI.SignalR
{

    /// <summary>
    /// 信息类型 
    /// </summary>
    public enum SignalRMessageType
    {
        File,
        [Description("图片")]
        Img,
        [Description("纯文本")]
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
        /// 发送时间
        /// </summary>
        public DateTime SenderTime { get; set; }

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
        public static SignalRMessagePackage GetPTPTextPackage(String context, int fromUserId, int toUserId, DateTime date)
        {
            SignalRMessagePackage srm = new SignalRMessagePackage();
            srm.Context = context;
            srm.Title = String.Empty;
            srm.FromUserId = fromUserId;
            srm.ToUserId = toUserId;
            srm.SCType = SignalRCommunicationType.PersonToPerson;
            srm.SMType = SignalRMessageType.Text;
            srm.SenderTime = date;
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
            srm.SenderTime = DateTime.Now;
            return srm;
        }

        /// <summary>
        /// 点对群通讯包
        /// </summary>
        /// <param name="context"></param>
        /// <param name="fromUserId"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public static SignalRMessagePackage GetPTGTextPackage(String context, int fromUserId, int groupId, DateTime date)
        {
            SignalRMessagePackage srm = new SignalRMessagePackage();
            srm.Context = context;
            srm.FromUserId = fromUserId;
            srm.SCType = SignalRCommunicationType.PersonToGroup;
            srm.SMType = SignalRMessageType.Text;
            srm.ToUserId = groupId;
            srm.SenderTime = date;
            return srm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="title">文件名（包括后缀）</param>
        /// <param name="fromUserId">发送者Id</param>
        /// <param name="groupId">接受者Id</param>
        /// <returns></returns>
        public static SignalRMessagePackage GetPTGImgPackage(String context, String title, int fromUserId, int groupId, DateTime date)
        {
            SignalRMessagePackage srm = new SignalRMessagePackage();
            srm.Title = title;
            srm.Context = context;
            srm.FromUserId = fromUserId;
            srm.SCType = SignalRCommunicationType.PersonToGroup;
            srm.SMType = SignalRMessageType.Img;
            srm.ToUserId = groupId;
            srm.SenderTime = date;
            return srm;
        }

        /// <summary>
        /// 点对点图片通讯包
        /// </summary>
        /// <param name="context"></param>
        /// <param name="title"></param>
        /// <param name="fromUserId"></param>
        /// <param name="toUserId"></param>
        /// <returns></returns>
        public static SignalRMessagePackage GetPTPImgPackage(String context, String title, int fromUserId, int toUserId, DateTime date)
        {
            SignalRMessagePackage srm = new SignalRMessagePackage();
            srm.Title = title;
            srm.Context = context;
            srm.FromUserId = fromUserId;
            srm.SCType = SignalRCommunicationType.PersonToPerson;
            srm.SMType = SignalRMessageType.Img;
            srm.ToUserId = toUserId;
            srm.SenderTime = date;
            return srm;
        }

        /// <summary>
        /// 点对点文件通讯包
        /// </summary>
        /// <param name="context"></param>
        /// <param name="title"></param>
        /// <param name="fromUserId"></param>
        /// <param name="toUserId"></param>
        /// <returns></returns>
        public static SignalRMessagePackage GetPTPFilePackage(String context, String title, int fromUserId, int toUserId, DateTime date)
        {
            SignalRMessagePackage srm = new SignalRMessagePackage();
            srm.Title = title;
            srm.Context = context;
            srm.FromUserId = fromUserId;
            srm.SCType = SignalRCommunicationType.PersonToPerson;
            srm.SMType = SignalRMessageType.File;
            srm.ToUserId = toUserId;
            srm.SenderTime = date;
            return srm;
        }

        /// <summary>
        /// 点对群文件通讯包
        /// </summary>
        /// <param name="context"></param>
        /// <param name="title"></param>
        /// <param name="fromUserId"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public static SignalRMessagePackage GetPTGFilePackage(String context, String title, int fromUserId, int groupId, DateTime date)
        {
            SignalRMessagePackage srm = new SignalRMessagePackage();
            srm.Title = title;
            srm.Context = context;
            srm.FromUserId = fromUserId;
            srm.SCType = SignalRCommunicationType.PersonToGroup;
            srm.SMType = SignalRMessageType.File;
            srm.ToUserId = groupId;
            srm.SenderTime = date;
            return srm;
        }

        public static SignalRMessagePackage GetPackage(UserMessageDTO node)
        {
            if (node.MessageType == (int)SignalRMessageType.Text)
            {
                return SignalRMessagePackageFactory.GetPTPTextPackage(node.Content, (int)node.FromUserId, (int)node.ToUserId, node.CreateTime == null ? DateTime.Now : (DateTime)node.CreateTime);
            }
            else if (node.MessageType == (int)SignalRMessageType.File)
            {
                return SignalRMessagePackageFactory.GetPTPFilePackage(node.Content, FileHelper.Decrept(node.Content), (int)node.FromUserId, (int)node.ToUserId, node.CreateTime == null ? DateTime.Now : (DateTime)node.CreateTime);
            }
            else if (node.MessageType == (int)SignalRMessageType.Img)
            {
                return SignalRMessagePackageFactory.GetPTPImgPackage(node.Content, FileHelper.Decrept(node.Content), (int)node.FromUserId, (int)node.ToUserId, node.CreateTime == null ? DateTime.Now : (DateTime)node.CreateTime);
            }
            else
            {
                return null;
            }
        }

        public static SignalRMessagePackage GetPackage(GroupMessagerDTO node)
        {
            if (node.MessageType == (int)SignalRMessageType.Text)
            {
                return SignalRMessagePackageFactory.GetPTGTextPackage(node.Content, (int)node.CrateUseId, (int)node.GroupId, node.CrateTime == null ? DateTime.Now : (DateTime)node.CrateTime);
            }
            else if (node.MessageType == (int)SignalRMessageType.File)
            {
                return SignalRMessagePackageFactory.GetPTGFilePackage(node.Content, FileHelper.Decrept(node.Content), (int)node.CrateUseId, (int)node.GroupId, node.CrateTime == null ? DateTime.Now : (DateTime)node.CrateTime);
            }
            else if (node.MessageType == (int)SignalRMessageType.Img)
            {
                return SignalRMessagePackageFactory.GetPTGImgPackage(node.Content, FileHelper.Decrept(node.Content), (int)node.CrateUseId, (int)node.GroupId, node.CrateTime == null ? DateTime.Now : (DateTime)node.CrateTime);
            }
            else
            {
                return null;
            }
        }
    }
}