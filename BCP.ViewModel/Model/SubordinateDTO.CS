using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// Subordinate DTO
    /// </summary>
    public partial class SubordinateDTO
    {
        public System.Int32 ID { get; set; }
        public System.String Code { get; set; }
        public System.String Name { get; set; }
        public System.String Descript { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
