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
    
    public partial class Tudi_TaskTypeCode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tudi_TaskTypeCode()
        {
            this.gtgl_TaskType1 = new HashSet<Tudi_TaskTypeCode>();
            this.gtgl_TaskCode = new HashSet<Tudi_gtgl_TaskCode>();
        }
    
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<int> Parent { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tudi_TaskTypeCode> gtgl_TaskType1 { get; set; }
        public virtual Tudi_TaskTypeCode gtgl_TaskType2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tudi_gtgl_TaskCode> gtgl_TaskCode { get; set; }
    }
}
