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
    
    public partial class Land_Graph_Handle
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string TaskContent { get; set; }
        public string ChangeDate { get; set; }
        public LandState CurrentState { get; set; }
        public string Notes { get; set; }
        public int Land_TaskTypeID { get; set; }
        public string Implementer { get; set; }
        public int Land_managerID { get; set; }
    
        public virtual Land_TaskType Land_TaskType { get; set; }
        public virtual Land_manager Land_manager { get; set; }
    }
}
