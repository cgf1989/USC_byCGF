using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// DocComent DTO
    /// </summary>
    public partial class DocComentDTO
    {
        public System.Int32 Id { get; set; }
        public System.Int32 DocLocationID { get; set; }
        public System.Int32 DocSenderId { get; set; }
        public System.String Remark { get; set; }
        public System.DateTime RemarkTime { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
