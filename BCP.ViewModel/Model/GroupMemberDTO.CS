using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// GroupMember DTO
    /// </summary>
    public partial class GroupMemberDTO
    {
        public System.Int32 ID { get; set; }
        public System.String Name { get; set; }
        public System.String Creator { get; set; }
        public System.Int32 UserID { get; set; }
        public System.DateTime JoinTime { get; set; }
        public System.String State { get; set; }
        public System.String Rule { get; set; }
        public Int32? GroupID { get; set; }
    }
}
