using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// AssetBaseType DTO
    /// </summary>
    public partial class AssetBaseTypeDTO
    {
        public System.Int32 Id { get; set; }
        public System.String TypeName { get; set; }
        public System.String Note { get; set; }
        public System.Int32 OrganizationID { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}

