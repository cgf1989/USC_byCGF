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
    
    public partial class UserMessage
    {
        public int Id { get; set; }
        public Nullable<int> FromUserId { get; set; }
        public Nullable<int> ToUserId { get; set; }
        public int MessageType { get; set; }
        public string Content { get; set; }
        public Nullable<int> State { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> CreateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public string UpdateUserId { get; set; }
    
        public virtual User User { get; set; }
    }
}
