using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// CustomGeographicType DTO
    /// </summary>
    public partial class CustomGeographicTypeDTO
    {
        public System.Int32 ID { get; set; }
        public System.String TypeName { get; set; }
        public System.String Descript { get; set; }
        public Int32? CustomGeographicTypeID { get; set; }
        public Int32? EventTimeEventTimeID { get; set; }
    }
}
