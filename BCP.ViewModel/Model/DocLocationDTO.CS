using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// DocLocation DTO
    /// </summary>
    public partial class DocLocationDTO
    {
        public System.Int32 ID { get; set; }
        public System.String VisualScope { get; set; }
        public System.Int32 DocReaderId { get; set; }
        public System.Boolean IsRuleTransaction { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}

