using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// ProductStandard DTO
    /// </summary>
    public partial class ProductStandardDTO
    {
        public System.Int32 ID { get; set; }
        public System.String ProductCode { get; set; }
        public System.String Name { get; set; }
        public System.String Descript { get; set; }
        public Int32? Parent { get; set; }
        public System.String measureUnit { get; set; }
        public System.String ParentCode { get; set; }
        public System.String Vesion { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
