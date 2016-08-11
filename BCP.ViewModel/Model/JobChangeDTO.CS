using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// JobChange DTO
    /// </summary>
    public partial class JobChangeDTO
    {
        public System.Int32 Id { get; set; }
        public Int32? EmployeeId { get; set; }
        public Int32? PostID { get; set; }
        public System.Boolean State { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public System.String Creater { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
