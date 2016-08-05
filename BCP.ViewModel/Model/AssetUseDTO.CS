using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// AssetUse DTO
    /// </summary>
    public partial class AssetUseDTO
    {
        public System.Int32 Id { get; set; }
        public System.Int32 physicalAssetId { get; set; }
        public System.String UseType { get; set; }
        public System.String User { get; set; }
        public System.String UseTime { get; set; }
        public System.String PlaceOfUse { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}

