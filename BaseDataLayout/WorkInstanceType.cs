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
    
    public partial class WorkInstanceType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkInstanceType()
        {
            this.WorkInstanceTypes = new HashSet<WorkInstanceType>();
            this.WorkSpaceTypes = new HashSet<WorkSpaceType>();
            this.DocLocations = new HashSet<DocLocation>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descript { get; set; }
        public Nullable<int> WorkInstanceTypeId { get; set; }
        public Nullable<int> WorkSpaceBaseTypeId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkInstanceType> WorkInstanceTypes { get; set; }
        public virtual WorkInstanceType WorkInstanceType1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkSpaceType> WorkSpaceTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocLocation> DocLocations { get; set; }
        public virtual WorkSpaceBaseType WorkSpaceBaseType { get; set; }
    }
}
