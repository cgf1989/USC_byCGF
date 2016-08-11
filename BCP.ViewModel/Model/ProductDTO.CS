using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// Product DTO
    /// </summary>
    public partial class ProductDTO
    {
        public System.Int32 Id { get; set; }
        public System.Int32 ProductStandardID { get; set; }
        public System.String Pname { get; set; }
        public System.String PModel { get; set; }
        public System.String Units { get; set; }
        public System.String SCode { get; set; }
        public System.String FCode { get; set; }
        public System.String PCode { get; set; }
        public Int32? OrganizBasicID { get; set; }
        public Int32? OrganizationID { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
