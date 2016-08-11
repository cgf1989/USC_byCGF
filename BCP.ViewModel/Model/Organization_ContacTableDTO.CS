using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// Organization_ContacTable DTO
    /// </summary>
    public partial class Organization_ContacTableDTO
    {
        public System.Int32 ID { get; set; }
        public System.Int32 OrganizBasicID { get; set; }
        public System.String Name { get; set; }
        public System.String Tools { get; set; }
        public System.String Value { get; set; }
        public System.Boolean IsValid { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
