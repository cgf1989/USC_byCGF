using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// DocReader DTO
    /// </summary>
    public partial class DocReaderDTO
    {
        public System.Int32 Id { get; set; }
        public Int32? WorkSpaceID { get; set; }
        public Int32? OrganizationID { get; set; }
        public Int32? PostID { get; set; }
        public Int32? UserID { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
