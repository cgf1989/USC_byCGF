using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// OrganizationEvent DTO
    /// </summary>
    public partial class OrganizationEventDTO
    {
        public System.Int32 ID { get; set; }
        public System.Int32 OrganizationID { get; set; }
        public System.String EventName { get; set; }
        public System.String EventContent { get; set; }
        public System.String EventType { get; set; }
        public System.String HanderSection { get; set; }
        public System.String Hander { get; set; }
        public System.String Result { get; set; }
        public System.String EventState { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
