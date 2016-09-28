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
        public System.Int32 Id { get; set; }
        public Int32? GroupId { get; set; }
        public Int32? GroupMemberId { get; set; }
        public Int32? MessageType { get; set; }
        public System.String Content { get; set; }
        public System.String Notes { get; set; }
        public DateTime? CrateTime { get; set; }
        public Int32? CrateUseId { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Int32? UpdateUserId { get; set; }
        public System.Boolean IsDeleted { get; set; }
    }
}
