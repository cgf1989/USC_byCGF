using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// WorkMessage DTO
    /// </summary>
    public partial class WorkMessageDTO
    {
        public System.Int32 Id { get; set; }
        public System.Int32 AuthorizationId { get; set; }
        public System.String Content { get; set; }
        public System.String Environment { get; set; }
        public System.String State { get; set; }
        public System.String Request { get; set; }
        public System.String Repose { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}

