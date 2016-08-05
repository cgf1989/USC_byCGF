using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// LoginLog DTO
    /// </summary>
    public partial class LoginLogDTO
    {
        public System.Int32 ID { get; set; }
        public System.String LoginIP { get; set; }
        public System.String LoginTime { get; set; }
        public System.String LogoutTime { get; set; }
        public System.String CurrentSate { get; set; }
    }
}

