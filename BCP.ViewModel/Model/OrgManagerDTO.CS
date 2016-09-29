using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// OrgManager DTO
    /// </summary>
    public partial class OrgManagerDTO
    {
        public System.Int32 Id { get; set; }
        public System.Int32 UserId { get; set; }
        public System.Boolean IsDeleted { get; set; }
        public System.String Notes { get; set; }
        public System.String State { get; set; }
        public Int32? CrateUserId { get; set; }
        public DateTime? CreateTime { get; set; }
        public Int32? UpdateUserId { get; set; }
        public DateTime? UpdateTime { get; set; }
        public System.Int32 OrganizationId { get; set; }
    }
}
