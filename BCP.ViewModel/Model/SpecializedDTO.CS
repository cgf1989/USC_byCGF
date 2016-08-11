using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// Specialized DTO
    /// </summary>
    public partial class SpecializedDTO
    {
        public System.Int32 ID { get; set; }
        public System.String Code { get; set; }
        public System.String SpecialName { get; set; }
        public System.String Descript { get; set; }
        public System.String ParentCode { get; set; }
        public Int32? Parent { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
