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
        public System.String StartTime { get; set; }
        public System.String EndTime { get; set; }
        public System.String EmpCode { get; set; }
        public System.Int32 UserID { get; set; }
        public System.String Isvalid { get; set; }
        public Int32? PositionID { get; set; }
        public Int32? OrganizationID { get; set; }
    }
}
