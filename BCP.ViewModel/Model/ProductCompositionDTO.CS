using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// ProductComposition DTO
    /// </summary>
    public partial class ProductCompositionDTO
    {
        public System.Int32 Id { get; set; }
        public System.Int32 ChildProductId { get; set; }
        public System.String Function { get; set; }
        public System.String descript { get; set; }
        public System.String Value { get; set; }
        public System.Int32 ProductCompositionId { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
