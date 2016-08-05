using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// DocumentManage DTO
    /// </summary>
    public partial class DocumentManageDTO
    {
        public System.Int32 ID { get; set; }
        public System.String Name { get; set; }
        public System.String Doctype { get; set; }
        public System.String Content { get; set; }
        public System.String URL { get; set; }
        public System.String FileNumber { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}

