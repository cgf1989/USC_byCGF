using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// ProductEvent DTO
    /// </summary>
    public partial class ProductEventDTO
    {
        public System.Int32 Id { get; set; }
        public System.String EventName { get; set; }
        public System.String Content { get; set; }
        public System.DateTime EventTime { get; set; }
        public System.Int32 ProductId { get; set; }
        public System.Int32 Creater { get; set; }
        public System.Int64 EventTime1 { get; set; }
    }
}
