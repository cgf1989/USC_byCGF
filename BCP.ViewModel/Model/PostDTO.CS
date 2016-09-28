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
        public System.String Descript { get; set; }
        public Int32? PostID { get; set; }
        public System.Int32 OrganizationID { get; set; }
        public Int32? EmployeeId { get; set; }
        public Int32? PositionID { get; set; }
        public System.String IsDeleted { get; set; }
        public System.String Notes { get; set; }
        public System.String State { get; set; }
        public System.Int32 CreateUserId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.Int32 UpdateUserId { get; set; }
        public System.DateTime UpdateTime { get; set; }
    }
}
