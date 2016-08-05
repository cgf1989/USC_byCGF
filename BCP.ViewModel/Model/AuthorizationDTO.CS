using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// Authorization DTO
    /// </summary>
    public partial class AuthorizationDTO
    {
        public System.Int32 Id { get; set; }
        public System.String PropertyValue { get; set; }
        public System.String PostRelation { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}

