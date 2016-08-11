using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// IndustrySolution DTO
    /// </summary>
    public partial class IndustrySolutionDTO
    {
        public System.Int32 Id { get; set; }
        public Int32? IndustryCodeID { get; set; }
        public System.String Name { get; set; }
        public System.String Content { get; set; }
        public System.String Note { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
