using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// Administrativecode DTO
    /// </summary>
    public partial class AdministrativecodeDTO
    {
        public System.Int32 ID { get; set; }
        public System.String DivisionCode { get; set; }
        public System.String RegionName { get; set; }
        public System.String ParentCode { get; set; }
        public Int32? Parent { get; set; }
        public System.String Vesion { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
