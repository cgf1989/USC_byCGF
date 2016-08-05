using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// Organization_Type DTO
    /// </summary>
    public partial class Organization_TypeDTO
    {
        public System.Int32 ID { get; set; }
        public System.String Ocode { get; set; }
        public System.String OName { get; set; }
        public System.String Descript { get; set; }
        public System.String ParentCode { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}

