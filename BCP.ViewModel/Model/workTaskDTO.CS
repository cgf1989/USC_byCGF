using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// workTask DTO
    /// </summary>
    public partial class workTaskDTO
    {
        public System.Int32 Id { get; set; }
        public System.String name { get; set; }
        public System.String Content { get; set; }
        public System.String BegeinTime { get; set; }
        public System.String EndTime { get; set; }
        public System.String State { get; set; }
    }
}

