//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaseDataLayout
{
    using System;
    using System.Collections.Generic;
    
    public partial class DesktopGeoManage
    {
        public int ID { get; set; }
        public string Tile { get; set; }
        public Nullable<int> EventTimeEventTimeID { get; set; }
        public string Content { get; set; }
        public string Descript { get; set; }
        public string link { get; set; }
        public int Geo_GraphID { get; set; }
        public int CustomGeographicTypeID { get; set; }
    
        public virtual Land_Graph Geo_Graph { get; set; }
        public virtual CustomGeographicType CustomGeographicType { get; set; }
    }
}
