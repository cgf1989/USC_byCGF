using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// Employee DTO
    /// </summary>
    public partial class EmployeeDTO
    {
        public System.Int32 Id { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public System.String EmpCode { get; set; }
        public System.Int32 UserID { get; set; }
        public Int32? PositionID { get; set; }
        public Int32? OrganizationID { get; set; }
        public System.String IsChief { get; set; }
        public System.Boolean IsDeleted { get; set; }
        public System.String State { get; set; }
        public System.String Notes { get; set; }
        public System.Int32 CreateUserId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.Int32 UpdateUserId { get; set; }
        public System.DateTime UpdateTime { get; set; }
    }
}
