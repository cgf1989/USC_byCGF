using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// Post DTO
    /// </summary>
    public partial class PostDTO
    {
        public System.Int32 ID { get; set; }
        public System.String PostName { get; set; }
        public System.String MarkerString { get; set; }
        public System.Boolean IsValid { get; set; }
        public System.String Descript { get; set; }
        public Int32? PostID { get; set; }
        public System.Int32 OrganizationID { get; set; }
        public Int32? EmployeeId { get; set; }
        public Int32? PositionID { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
