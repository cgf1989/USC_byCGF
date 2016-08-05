using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// ModulProperty DTO
    /// </summary>
    public partial class ModulPropertyDTO
    {
        public System.Int32 Id { get; set; }
        public System.Int32 WorkModulId { get; set; }
        public System.String Name { get; set; }
        public System.String Type { get; set; }
        public System.String Descript { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}

