using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// OperationEvent DTO
    /// </summary>
    public partial class OperationEventDTO
    {
        public System.Int32 Id { get; set; }
        public System.String OperType { get; set; }
        public System.String OperName { get; set; }
        public System.String OperModul { get; set; }
        public System.String OperTime { get; set; }
        public System.String OperSpace { get; set; }
        public System.String Note { get; set; }
        public Int32? LoginLogID { get; set; }
    }
}
