using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// OrgaRegisterDocment DTO
    /// </summary>
    public partial class OrgaRegisterDocmentDTO
    {
        public System.Int32 ID { get; set; }
        public System.Int32 OrganizBasicID { get; set; }
        public System.String DocumentName { get; set; }
        public System.Int32 RegisterDocumentTypeID { get; set; }
        public System.Byte[] DocmentContent { get; set; }
        public System.String DocumentFormat { get; set; }
        public System.DateTime RecordeTime { get; set; }
        public System.Int64 EventTime { get; set; }
        public System.Int64 EventTime1 { get; set; }
    }
}

