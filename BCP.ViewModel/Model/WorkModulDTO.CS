using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// WorkModul DTO
    /// </summary>
    public partial class WorkModulDTO
    {
        public System.Int32 Id { get; set; }
        public Int32? FunctionGroupID { get; set; }
        public System.String Name { get; set; }
        public System.String Content { get; set; }
        public System.String ActivityType { get; set; }
        public Int32? WorkModulId { get; set; }
        public Int32? DllFileStreamID { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
