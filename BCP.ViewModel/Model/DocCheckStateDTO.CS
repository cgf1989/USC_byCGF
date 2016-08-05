using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// DocCheckState DTO
    /// </summary>
    public partial class DocCheckStateDTO
    {
        public System.Int32 ID { get; set; }
        public System.String Post { get; set; }
        public System.String UserName { get; set; }
        public System.Boolean CheckState { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}

