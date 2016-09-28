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
        public System.DateTime LimitTime { get; set; }
        public System.String Domain { get; set; }
        public System.String DomainId { get; set; }
        public System.Int32 State { get; set; }
        public System.String Notes { get; set; }
        public DateTime? CreateTime { get; set; }
        public Int32? CreateUserId { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Int32? UpdateUserId { get; set; }
        public System.Boolean IsDeleted { get; set; }
    }
}
