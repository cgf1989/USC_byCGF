using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// CustomTabData DTO
    /// </summary>
    public partial class CustomTabDataDTO
    {
        public System.Int32 Id { get; set; }
        public System.String Data { get; set; }
        public System.Int32 CustomTableId { get; set; }
        public Int32? DocumentManageID { get; set; }
    }
}
