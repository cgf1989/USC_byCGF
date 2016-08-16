using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// OperationDetail DTO
    /// </summary>
    public partial class OperationDetailDTO
    {
        public System.Int32 Id { get; set; }
        public System.String TabName { get; set; }
        public System.String TabRecordId { get; set; }
        public System.String HandleType { get; set; }
        public Int32? OpenEventId { get; set; }
        public System.String Note { get; set; }
    }
}
