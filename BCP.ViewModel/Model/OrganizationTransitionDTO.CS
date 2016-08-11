using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// OrganizationTransition DTO
    /// </summary>
    public partial class OrganizationTransitionDTO
    {
        public System.Int32 ID { get; set; }
        public System.String Cause { get; set; }
        public System.String FundAlteration { get; set; }
        public System.String PropertyAlteration { get; set; }
        public System.DateTime Time { get; set; }
        public System.String Others { get; set; }
        public System.String Description { get; set; }
        public Int32? OldOrgan { get; set; }
        public Int32? NewOrgan { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
