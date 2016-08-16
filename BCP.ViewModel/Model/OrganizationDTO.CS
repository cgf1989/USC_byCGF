using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// Organization DTO
    /// </summary>
    public partial class OrganizationDTO
    {
        public System.Int32 ID { get; set; }
        public System.String OrganizationCode { get; set; }
        public System.String OrgaName { get; set; }
        public System.String Certificates { get; set; }
        public DateTime? EstablishmentDate { get; set; }
        public Int32? Parent { get; set; }
        public System.String MarkerString { get; set; }
        public System.Boolean IsValid { get; set; }
        public System.String Type { get; set; }
    }
}
