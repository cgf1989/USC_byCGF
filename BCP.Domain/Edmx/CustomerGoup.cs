//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BCP.Domain.Edmx
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerGoup
    {
        public int ID { get; set; }
        public string GroupName { get; set; }
        public int CreatID { get; set; }
        public Nullable<int> UserID { get; set; }
        public long EventTime { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
