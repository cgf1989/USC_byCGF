using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// UserRelateTable DTO
    /// </summary>
    public partial class UserRelateTableDTO
    {
        public System.Int32 ID { get; set; }
        public System.Int32 UserID { get; set; }
        public System.Int32 UserID1 { get; set; }
        public System.Int32 UserRelateTypeID { get; set; }
        public System.String RelateObject { get; set; }
        public System.String Notes { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
