using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// ProductCustomCategory DTO
    /// </summary>
    public partial class ProductCustomCategoryDTO
    {
        public System.Int32 Id { get; set; }
        public System.String CategoryName { get; set; }
        public System.String Content { get; set; }
        public System.Int32 ProductCustomCategoryId { get; set; }
    }
}
