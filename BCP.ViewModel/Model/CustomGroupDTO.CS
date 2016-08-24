using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// CustomGroup DTO
    /// </summary>
    public partial class CustomGroupDTO
    {
        public System.Int32 Id { get; set; }
        public System.String GroupName { get; set; }
        public System.String Notes { get; set; }
        public DateTime? CreatTime { get; set; }
        public Int32? CreateUserId { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Int32? UpdateUserId { get; set; }
    }
}
