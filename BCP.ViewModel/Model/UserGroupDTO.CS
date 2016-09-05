using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// UserGroup DTO
    /// </summary>
    public partial class UserGroupDTO
    {
        public System.Int32 ID { get; set; }
        public System.String Name { get; set; }
        public System.String Creator { get; set; }
        public System.Int32 UserID { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.String State { get; set; }
        public System.Int32 GroupNameID { get; set; }
        public System.String Rule { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
