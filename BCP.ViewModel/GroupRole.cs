using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    public enum  GroupRole
    {
        [Description("创建者")]
        GroupCreator,
        [Description("管理员")]
        GroupManager,
        [Description("成员")]
        GroupMember
    }
}
