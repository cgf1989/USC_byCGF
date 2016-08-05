using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// WorkSpace DTO
    /// </summary>
    public partial class WorkSpaceDTO
    {
        public System.Int32 ID { get; set; }
        public System.String Name { get; set; }
        public System.String Content { get; set; }
        public System.String MarkerString { get; set; }
        public System.String Comment { get; set; }
        public System.Boolean IsValid { get; set; }
        public System.String Descript { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}

