using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// UserMessage DTO
    /// </summary>
    public partial class UserMessageDTO
    {
        public System.Int32 Id { get; set; }
        public Int32? FromUserId { get; set; }
        public Int32? ToUserId { get; set; }
        public System.Int32 MessageType { get; set; }
        public System.String Content { get; set; }
        public Int32? State { get; set; }
        public System.String Notes { get; set; }
        public DateTime? CreateTime { get; set; }
        public Int32? CreateUserId { get; set; }
        public DateTime? UpdateTime { get; set; }
        public System.String UpdateUserId { get; set; }
    }
}
