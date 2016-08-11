using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// OrganizationCustomType DTO
    /// </summary>
    public partial class OrganizationCustomTypeDTO
    {
        public System.Int32 ID { get; set; }
        public System.Int32 OrganizationID { get; set; }
        public System.Int32 CustomCategoryID { get; set; }
        public System.String note { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
