using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// WorkSpaceRole DTO
    /// </summary>
    public partial class WorkSpaceRoleDTO
    {
        public System.Int32 Id { get; set; }
        public System.String Type { get; set; }
        public System.Int32 WorkSpaceID { get; set; }
        public System.Int32 OrganizationID { get; set; }
        public System.String Descript { get; set; }
        public Int32? WorkModulId { get; set; }
        public Int32? UserID { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
