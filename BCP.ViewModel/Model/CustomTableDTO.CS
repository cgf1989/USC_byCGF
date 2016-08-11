using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// CustomTable DTO
    /// </summary>
    public partial class CustomTableDTO
    {
        public System.Int32 Id { get; set; }
        public System.String ColumnName { get; set; }
        public System.String DataType { get; set; }
    }
}
