using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// 通信包
    /// 
    /// </summary>
    public class CommunitcationPackage
    {
        //通行方式
        public CommunitcationType CType { get; set; }

        public MessageType MType { get; set; }

        public object Content { get; set; }

        public DateTime SendTime { get; set; }
    }

    /// <summary>
    /// 通行方式 个人-个人，个人-群组
    /// </summary>
    public enum CommunitcationType
    {
        PersonToPerson,PersonToGroup
    }

    /// <summary>
    /// 信息类型 doc文档 图片 文字
    /// </summary>
    public enum MessageType 
    {
        Doc,Pic,Text
    }
}
