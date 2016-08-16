using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// User DTO
    /// </summary>
    public partial class UserDTO
    {
        public System.Int32 ID { get; set; }
        public System.String UserName { get; set; }
        public System.String Password { get; set; }
        public System.String ActualName { get; set; }
        public System.String Status { get; set; }
        public System.DateTime LimiteTime { get; set; }
        public System.String Note { get; set; }
        public System.String Domain { get; set; }
        public System.String DomainId { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
