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
    
    public partial class OperationEvent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OperationEvent()
        {
            this.EventTimes = new HashSet<OperationDetail>();
        }
    
        public int Id { get; set; }
        public string OperType { get; set; }
        public string OperName { get; set; }
        public string OperModul { get; set; }
        public string OperTime { get; set; }
        public string OperSpace { get; set; }
        public string Note { get; set; }
        public Nullable<int> LoginLogID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OperationDetail> EventTimes { get; set; }
        public virtual LoginLog LoginLog { get; set; }
    }
}
