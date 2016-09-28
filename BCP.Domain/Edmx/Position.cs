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
    
    public partial class Position
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Position()
        {
            this.Employees = new HashSet<Employee>();
        }
    
        public int Id { get; set; }
        public string PositionType { get; set; }
        public string Name { get; set; }
        public string TaskNature { get; set; }
        public Nullable<int> PositionID { get; set; }
        public int OrganizationID { get; set; }
        public Nullable<int> PostRequireID { get; set; }
        public int PositionLevel { get; set; }
        public string IsDeleted { get; set; }
        public string State { get; set; }
        public string Notes { get; set; }
        public int CreateUserId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int UpdateUserId { get; set; }
        public System.DateTime UpdateTime { get; set; }
    
        public virtual Organization Organization { get; set; }
        public virtual PostRequire PostRequire { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
