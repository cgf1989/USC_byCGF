using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// OrganizationAssetType DTO
    /// </summary>
    public partial class OrganizationAssetTypeDTO
    {
        public System.Int32 Id { get; set; }
        public System.String Name { get; set; }
        public System.String Note { get; set; }
        public Int32? physicalAssetId { get; set; }
        public System.Int32 AssetBaseTypeId { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
