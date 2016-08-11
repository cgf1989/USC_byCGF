using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// DllFileStream DTO
    /// </summary>
    public partial class DllFileStreamDTO
    {
        public System.Int32 ID { get; set; }
        public Int32? IndustrySolutionId { get; set; }
        public Int32? DllFileStreamID { get; set; }
        public System.String Model { get; set; }
        public System.Byte[] DllfileStream { get; set; }
        public System.String FileName { get; set; }
        public Boolean? MainWindowName { get; set; }
        public System.String Txt2 { get; set; }
        public System.String URI { get; set; }
        public System.String Paragram { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
