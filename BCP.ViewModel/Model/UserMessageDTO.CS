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
        public System.Int32 ID { get; set; }
        public System.String Content { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.String State { get; set; }
        public System.Int32 SenderID { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}

