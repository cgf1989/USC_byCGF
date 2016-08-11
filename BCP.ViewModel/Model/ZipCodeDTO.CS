using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// ZipCode DTO
    /// </summary>
    public partial class ZipCodeDTO
    {
        public System.Int32 ID { get; set; }
        public System.String Code { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
