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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserMessage()
        {
            this.UserMessages = new HashSet<UserMessage>();
        }
    
        public int ID { get; set; }
        public string Content { get; set; }
        public Nullable<int> ParetId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string State { get; set; }
        public Nullable<int> LoginLogID { get; set; }
        public int SenderID { get; set; }
        public long EventTime { get; set; }
        public int ReplyID { get; set; }
    
        public virtual LoginLog LoginLog { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserMessage> UserMessages { get; set; }
        public virtual UserMessage UserMessage1 { get; set; }
        public virtual User User { get; set; }
    }
}
