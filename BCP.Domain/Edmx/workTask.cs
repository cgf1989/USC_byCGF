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
    
    public partial class workTask
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public workTask()
        {
            this.workTasks = new HashSet<workTask>();
            this.DocumentContents = new HashSet<DocumentContent>();
        }
    
        public int Id { get; set; }
        public string name { get; set; }
        public string Content { get; set; }
        public string BegeinTime { get; set; }
        public string EndTime { get; set; }
        public string State { get; set; }
        public Nullable<int> DocumentManageID { get; set; }
        public Nullable<int> workTaskId { get; set; }
    
        public virtual DocumentManage DocumentManage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<workTask> workTasks { get; set; }
        public virtual workTask workTask1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocumentContent> DocumentContents { get; set; }
    }
}
