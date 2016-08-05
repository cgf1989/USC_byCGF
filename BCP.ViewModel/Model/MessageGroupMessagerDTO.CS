using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// MessageGroupMessager DTO
    /// </summary>
    public partial class MessageGroupMessagerDTO
    {
        public System.Int32 ID { get; set; }
        public System.String Title { get; set; }
        public System.String Content { get; set; }
        public System.Int32 MessageGroupID { get; set; }
        public System.String SendTime { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}

