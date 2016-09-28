using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// Position DTO
    /// </summary>
    public partial class PositionDTO
    {
        public System.Int32 Id { get; set; }
        public System.String PositionType { get; set; }
        public System.String Name { get; set; }
        public System.String TaskNature { get; set; }
        public Int32? PositionID { get; set; }
        public System.Int32 OrganizationID { get; set; }
        public Int32? PostRequireID { get; set; }
        public System.Int32 PositionLevel { get; set; }
        public System.String IsDeleted { get; set; }
        public System.String State { get; set; }
        public System.String Notes { get; set; }
        public System.Int32 CreateUserId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.Int32 UpdateUserId { get; set; }
        public System.DateTime UpdateTime { get; set; }
    }
}
