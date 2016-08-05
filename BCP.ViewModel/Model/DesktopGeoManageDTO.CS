using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// DesktopGeoManage DTO
    /// </summary>
    public partial class DesktopGeoManageDTO
    {
        public System.Int32 ID { get; set; }
        public System.String Tile { get; set; }
        public System.String Content { get; set; }
        public System.String Descript { get; set; }
        public System.String link { get; set; }
        public System.Int32 Geo_GraphID { get; set; }
        public System.Int32 CustomGeographicTypeID { get; set; }
    }
}

