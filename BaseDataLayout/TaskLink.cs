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
    
    public partial class TaskLink
    {
        public int ID { get; set; }
        public string LinkName { get; set; }
        public string LinkType { get; set; }
        public string Location { get; set; }
        public string Descript { get; set; }
        public Nullable<int> TaskID { get; set; }
    
        public virtual Task Task { get; set; }
    }
}
