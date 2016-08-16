using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// OrganizationOtherName DTO
    /// </summary>
    public partial class OrganizationOtherNameDTO
    {
        public System.Int32 ID { get; set; }
        public System.String OtherName { get; set; }
        public System.Int32 OrganizationID { get; set; }
    }
}
