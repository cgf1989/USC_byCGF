using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// OrganicInvestor DTO
    /// </summary>
    public partial class OrganicInvestorDTO
    {
        public System.Int32 ID { get; set; }
        public Int32? Investor { get; set; }
        public System.String InvestorName { get; set; }
        public System.Int32 InvestorNumber { get; set; }
        public System.String CentisifierType { get; set; }
        public System.Int32 OrganizBasicID { get; set; }
        public System.Decimal Amount { get; set; }
        public System.String Unit { get; set; }
        public System.String Currency { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
