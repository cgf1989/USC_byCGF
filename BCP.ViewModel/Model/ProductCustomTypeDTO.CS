using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// ProductCustomType DTO
    /// </summary>
    public partial class ProductCustomTypeDTO
    {
        public System.Int32 Id { get; set; }
        public System.Int32 ProductId { get; set; }
        public System.Int32 ProductCustomCategoryId { get; set; }
        public System.String Descript { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
