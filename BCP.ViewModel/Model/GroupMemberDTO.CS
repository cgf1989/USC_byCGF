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
        public System.Int32 Id { get; set; }
        public Int32? GroupId { get; set; }
        public Int32? UserId { get; set; }
        public System.String Name { get; set; }
        public Int32? ReferenceUserId { get; set; }
        public Int32? ApproveUserId { get; set; }
        public System.String GroupRole { get; set; }
        public Int32? State { get; set; }
        public System.String Notes { get; set; }
        public Int32? CreateUserId { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTiime { get; set; }
        public Int32? UpdateUserId { get; set; }
        public System.Boolean IsDeleted { get; set; }
    }
}
