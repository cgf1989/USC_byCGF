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
    
    public partial class CustomCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomCategory()
        {
            this.CustomOrganizationTypes = new HashSet<OrganizationCustomType>();
            this.CustomCategories = new HashSet<CustomCategory>();
        }
    
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string content { get; set; }
        public Nullable<int> CustomCategoryID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizationCustomType> CustomOrganizationTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomCategory> CustomCategories { get; set; }
        public virtual CustomCategory CustomCategory1 { get; set; }
    }
}
