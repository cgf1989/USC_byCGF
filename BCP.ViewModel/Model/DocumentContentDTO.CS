using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// DocumentContent DTO
    /// </summary>
    public partial class DocumentContentDTO
    {
        public System.Int32 ID { get; set; }
        public System.String Content { get; set; }
        public System.String Message { get; set; }
        public Int32? DocumentManageID { get; set; }
        public Int32? DocumentContentID { get; set; }
        public Int32? workTaskId { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
