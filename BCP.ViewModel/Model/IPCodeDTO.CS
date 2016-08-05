using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// IPCode DTO
    /// </summary>
    public partial class IPCodeDTO
    {
        public System.Int32 ID { get; set; }
        public System.String IP { get; set; }
        public System.String Company { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}

