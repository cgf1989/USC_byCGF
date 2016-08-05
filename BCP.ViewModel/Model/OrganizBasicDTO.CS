using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// OrganizBasic DTO
    /// </summary>
    public partial class OrganizBasicDTO
    {
        public System.Int32 ID { get; set; }
        public System.String RegistrationNumber { get; set; }
        public System.String Domicile { get; set; }
        public System.String BussinessAddress { get; set; }
        public System.String BussinessAddressDetail { get; set; }
        public System.String RegisteredCapital { get; set; }
        public System.String BusinessScope { get; set; }
        public System.String BussinessModel { get; set; }
        public System.Int32 Organization_TypeID { get; set; }
        public System.String SupervisorSection { get; set; }
        public System.String OperatingPeriod { get; set; }
        public System.String OtherInfo { get; set; }
        public System.Int32 OrganizationID { get; set; }
        public System.Int32 IndustryCodeID { get; set; }
        public System.Int32 AdministrativecodeSacID { get; set; }
        public System.Boolean IsValid { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}

