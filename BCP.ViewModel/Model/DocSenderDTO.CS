using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// DocSender DTO
    /// </summary>
    public partial class DocSenderDTO
    {
        public System.Int32 Id { get; set; }
        public Int32? UserID { get; set; }
        public Int32? PostID { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
