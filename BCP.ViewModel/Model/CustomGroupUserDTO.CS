using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// CustomGroupUser DTO
    /// </summary>
    public partial class CustomGroupUserDTO
    {
        public System.Int32 Id { get; set; }
        public Int32? GroupId { get; set; }
        public Int32? UserId { get; set; }
        public System.String Notes { get; set; }
        public DateTime? CreateTime { get; set; }
        public Int32? CreateUserId { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Int32? UpdateUserId { get; set; }
        public System.Boolean IsDeleted { get; set; }
    }
}
