using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// RegisterDocumentType DTO
    /// </summary>
    public partial class RegisterDocumentTypeDTO
    {
        public System.Int32 ID { get; set; }
        public System.String TypeName { get; set; }
        public System.Int64 EventTime { get; set; }
        public System.Int64 EventTime1 { get; set; }
        public System.Int64 EventTime2 { get; set; }
    }
}
