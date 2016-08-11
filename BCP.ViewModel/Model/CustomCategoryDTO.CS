using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// CustomCategory DTO
    /// </summary>
    public partial class CustomCategoryDTO
    {
        public System.Int32 ID { get; set; }
        public System.String CategoryName { get; set; }
        public System.String content { get; set; }
        public Int32? CustomCategoryID { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
