using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// Group DTO
    /// </summary>
    public partial class GroupDTO
    {
        public System.Int32 Id { get; set; }
        public Int32? UserId { get; set; }
        public System.String GroupNo { get; set; }
        public System.String Name { get; set; }
        public System.String Category { get; set; }
        public Int32? ValidattionPattern { get; set; }
        public Int16? State { get; set; }
        public System.String Notes { get; set; }
        public DateTime? CreatTime { get; set; }
        public Int32? CreateUserId { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Int32? UpdateUserId { get; set; }
        public System.Boolean IsDeleted { get; set; }
    }
}
