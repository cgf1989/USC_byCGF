using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// Organization DTO
    /// </summary>
    public partial class OrganizationDTO
    {
        public System.Int32 Id { get; set; }
        public System.String OrganizationCode { get; set; }
        public System.String OrgaName { get; set; }
        public System.String Certificates { get; set; }
        public Int32? ParentId { get; set; }
        public System.String MarkerString { get; set; }
        public System.String Type { get; set; }
        public System.Int32 RootId { get; set; }
        public System.String IsRoot { get; set; }
        public System.Boolean IsDeleted { get; set; }
        public System.String Notes { get; set; }
        public System.String State { get; set; }
        public System.Int32 CreateUserId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.Int32 UpdateUserId { get; set; }
        public System.DateTime UpdateTime { get; set; }
    }
}
