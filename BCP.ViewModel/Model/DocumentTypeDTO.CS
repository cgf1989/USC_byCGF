using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// DocumentType DTO
    /// </summary>
    public partial class DocumentTypeDTO
    {
        public System.Int32 ID { get; set; }
        public System.String TypeName { get; set; }
        public System.String Type { get; set; }
        public System.String Note { get; set; }
        public Int32? DocumentTypeID { get; set; }
        public Int32? OrigId { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
