using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// GroupMessager DTO
    /// </summary>
    public partial class GroupMessagerDTO
    {
        public System.Int32 ID { get; set; }
        public System.String Type { get; set; }
        public System.String Content { get; set; }
        public System.String SendTime { get; set; }
        public Int32? GroupMemberID { get; set; }
        public Int32? GroupID { get; set; }
    }
}
