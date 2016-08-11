using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// DocManageState DTO
    /// </summary>
    public partial class DocManageStateDTO
    {
        public System.Int32 ID { get; set; }
        public System.String DState { get; set; }
        public System.String DStateName { get; set; }
        public Int32? DocManageStateID { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
