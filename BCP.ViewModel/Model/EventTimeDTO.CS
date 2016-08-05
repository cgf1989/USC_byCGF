using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// EventTime DTO
    /// </summary>
    public partial class EventTimeDTO
    {
        public System.Int32 Id { get; set; }
        public System.String TimePoint { get; set; }
        public System.String SpacePoint { get; set; }
        public System.String EventName { get; set; }
        public System.String EventType { get; set; }
        public System.String District { get; set; }
    }
}

