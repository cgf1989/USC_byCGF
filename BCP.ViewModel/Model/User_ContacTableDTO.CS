using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// User_ContacTable DTO
    /// </summary>
    public partial class User_ContacTableDTO
    {
        public System.Int32 ID { get; set; }
        public System.String Name { get; set; }
        public System.String Tools { get; set; }
        public System.String Value { get; set; }
        public Int32? UserID { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
