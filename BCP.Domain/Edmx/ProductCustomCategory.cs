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
    
    public partial class ProductCustomCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductCustomCategory()
        {
            this.ProductCustomCategories = new HashSet<ProductCustomCategory>();
            this.ProductCustomTypes = new HashSet<ProductCustomType>();
        }
    
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Content { get; set; }
        public int ProductCustomCategoryId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductCustomCategory> ProductCustomCategories { get; set; }
        public virtual ProductCustomCategory ProductCustomCategory1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductCustomType> ProductCustomTypes { get; set; }
    }
}
