using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// physicalAsset DTO
    /// </summary>
    public partial class physicalAssetDTO
    {
        public System.Int32 Id { get; set; }
        public System.Int32 OrganizationID { get; set; }
        public System.Int32 ProductId { get; set; }
        public System.String PlaceOfBuy { get; set; }
        public System.String BuyTime { get; set; }
        public System.String Validity { get; set; }
        public System.String State { get; set; }
        public System.Decimal Value { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}

