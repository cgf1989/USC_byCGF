using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// AssetMaintenance DTO
    /// </summary>
    public partial class AssetMaintenanceDTO
    {
        public System.Int32 Id { get; set; }
        public System.Int32 physicalAssetId { get; set; }
        public System.Int32 Maintenancer { get; set; }
        public System.String Description { get; set; }
        public System.String Experience { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}

