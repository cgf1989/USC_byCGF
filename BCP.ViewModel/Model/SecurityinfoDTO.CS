using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// Securityinfo DTO
    /// </summary>
    public partial class SecurityinfoDTO
    {
        public System.Int32 ID { get; set; }
        public System.String SecurityName { get; set; }
        public System.Int32 Level { get; set; }
        public System.String Descript { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}

