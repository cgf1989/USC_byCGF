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
    
    public partial class OrganizationOtherName
    {
        public int ID { get; set; }
        public string OtherName { get; set; }
        public int OrganizationID { get; set; }
    
        public virtual Organization Organization { get; set; }
    }
}
