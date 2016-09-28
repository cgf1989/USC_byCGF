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
        public System.String UserId { get; set; }
        public System.String OrgId { get; set; }
        public System.String IsDeleted { get; set; }
        public System.String Notes { get; set; }
        public System.String State { get; set; }
        public System.String CrateUserId { get; set; }
        public System.String CreateTime { get; set; }
        public System.String UpdateUserId { get; set; }
        public System.String UpdateTime { get; set; }
    }
}
